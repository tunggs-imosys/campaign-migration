using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Newtonsoft.Json.Linq;
using Utils.Json;
using System.Linq;
using System.IO;
using UnityEngine.Events;
using System;
using SimpleFileBrowser;
using MyBox;

public class JSONMigration : MonoBehaviour
{
  public UnityEventString OnParseError = new UnityEventString();
  public UnityEvent OnParseSuccess = new UnityEvent();
  public UnityEvent OnSaveSuccess = new UnityEvent();
  public string BulletSpawnerQuery = string.Empty;
  public Dictionary<string, JObject> files
    = new Dictionary<string, JObject>();

  public void BrowseForFile() => FileBrowser.ShowLoadDialog(LoadCampaign,
    delegate { },
    false,
    true,
    string.Empty,
    "Select campaign files");

  void LoadCampaign(string[] paths)
  {
    try
    {
      files = paths.ToDictionary(Path.GetFileName,
        p => File.ReadAllText(p).PassTo(JObject.Parse));
      files.Values.SelectMany(o => o.SelectTokens(BulletSpawnerQuery))
        .Cast<JObject>()
        .ForEach(s =>
        {
          var delay = s["delay"].Value<float>();
          s.EnsureProperty("InUse", delay != -10);
          s["delay"] = delay == -10 ? 0 : delay;
        });
      files.Values.SelectMany(o => o.SelectTokens("$.diffs[*]"))
        .Cast<JObject>()
        .ForEach(d => d.SelectTokens("waves[*].planes[*]").Cast<JObject>()
          .ForEach(p =>
          {
            var waveInfoIndex = p["info"].Value<int>();
            var id = waveInfoIndex
              .InRange(0, d.SelectTokens("enemies[*]").Count()) ?
              d.SelectToken($"enemies[{waveInfoIndex}]")
                .As<JObject>()["id"]
                .Value<int>() :
              p.ContainsKey("ID") ? p["ID"].Value<int>() :
              -1;
            p.EnsureProperty("ID", id);
          }));
      files.Values.ForEach(r =>
      {
        var HPMultiplier = !r.ContainsKey("HPMultiplier") ?
          1f :
          r["HPMultiplier"].Value<float>() == 0f ?
          1f :
          r["HPMultiplier"];
        var ATKMultiplier = !r.ContainsKey("ATKMultiplier") ?
          1f :
          r["ATKMultiplier"].Value<float>() == 0f ?
          1f :
          r["ATKMultiplier"];
        r.SelectTokens("$.diffs[*]").Cast<JObject>()
          .ForEach(d =>
          {
            if (!d.ContainsKey("HPMultiplier"))
              d.Add(new JProperty("HPMultiplier", HPMultiplier));
            else if (d["HPMultiplier"].Value<float>() == 0)
              d["HPMultiplier"] = HPMultiplier;

            if (!d.ContainsKey("ATKMultiplier"))
              d.Add(new JProperty("ATKMultiplier", ATKMultiplier));
            else if (d["ATKMultiplier"].Value<float>() == 0)
              d["ATKMultiplier"] = ATKMultiplier;
          });
        r.Remove("HPMultiplier");
        r.Remove("ATKMultiplier");
        if (!r.ContainsKey("FormatVersion"))
          r.AddFirst(new JProperty("FormatVersion", Application.version));
      });
      files.Values.SelectMany(o => o.SelectTokens("$.diffs[*]"))
        .Cast<JObject>()
        .ForEach(d =>
        {
          if (!d.ContainsKey("enemies")) return;
          var oldSets = d.SelectToken("enemies") as JArray;
          var setDictionary = JArray.Parse("[]");
          d.SelectTokens("waves[*].planes[*]").Cast<JObject>()
            .Select(p => p["ID"].Value<int>())
            .Distinct()
            .Select(id => new JObject(
              new JProperty("Key", id),
              new JProperty("Value", new JObject(
                new JProperty("Values", new JArray(oldSets
                  .Where(set => set["id"].Value<int>() == id)
                  .Select(set => new JObject(
                    new JProperty("dam", set["dam"]),
                    new JProperty("hp", set["hp"]),
                    new JProperty("speed", set["speed"])
                  ))))))))
            .ForEach(setDictionary.Add);
          d.SelectTokens("waves[*].planes[*]").Cast<JObject>().ForEach(p =>
          {
            var setIndex = p["info"].Value<int>();
            setIndex = setIndex.ClampTo(0, oldSets.Count);
            var planeID = p["ID"].Value<int>();
            if (oldSets[setIndex]["id"].Value<int>() != planeID)
              oldSets.FirstIndex(set => set["id"].Value<int>() == planeID);
            var matchingSetIndices = oldSets.IndicesWhere(
              set => set["id"].Value<int>() == planeID);
            p["SetIndex"] = matchingSetIndices.IndexOfItem(setIndex);
            p["info"].Parent.Remove();
          });
          oldSets.Parent.Remove();
          d["StatSets"] = setDictionary;
        });
      OnParseSuccess.Invoke();
    }
    catch (IOException e)
    {
      Debug.Log(e.Message);
      OnParseError.Invoke($"Parse Error");
    }
  }

  public void SaveConvertedFile() => FileBrowser.ShowSaveDialog(paths =>
    {
      files.ForEach(p => File.WriteAllText($"{paths[0]}/{p.Key}",
        p.Value.ToString()));
      OnSaveSuccess.Invoke();
    },
    OnSaveSuccess.Invoke,
    true,
    false,
    string.Empty,
    "Save campaign files");
}

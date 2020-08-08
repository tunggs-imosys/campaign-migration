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
          .ForEach(p => p.EnsureProperty("ID",
            d.SelectToken($"enemies[{p["info"].Value<int>()}]")
              .As<JObject>()
              ["id"])));
      OnParseSuccess.Invoke();
    }
    catch (Exception e) { OnParseError.Invoke($"Parse Error"); }
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

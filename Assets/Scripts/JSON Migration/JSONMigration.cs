using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Newtonsoft.Json.Linq;
using UnityEditor;
using System.Linq;
using System.IO;
using UnityEngine.Events;
using System;

public class JSONMigration : MonoBehaviour
{
  public UnityEventString OnParseError = new UnityEventString();
  public UnityEvent OnParseSuccess = new UnityEvent();
  public UnityEvent OnSaveSuccess = new UnityEvent();
  string _fileText = string.Empty;
  JObject _campaign = null;

  public void BrowseForFile()
  {
    var path = EditorUtility.OpenFilePanelWithFilters("Select campaign file",
      string.Empty,
      new string[] { "JSON campaign file", "json" });
    _fileText = File.ReadAllText(path);

    try
    {
      _campaign = JObject.Parse(_fileText);
      _campaign
        .SelectTokens("$.diffs[*].waves[*].planes[*].bulletSpawnerDatas[*]")
        .Cast<JObject>()
        .ForEach(s =>
        {
          var delay = s["delay"].Value<float>();
          if (s.ContainsKey("InUse")) s["InUse"] = delay != -10;
          else s.Add("InUse", delay != -10);
          s["delay"] = delay == -10 ? 0 : delay;
        });
      OnParseSuccess.Invoke();
    }
    catch (Exception e) { OnParseError.Invoke($"Parse Error"); }
  }

  public void SaveConvertedFile()
  {
    var path = EditorUtility.SaveFilePanel("Save campaign file",
      string.Empty,
      string.Empty,
      "json");
    File.WriteAllText(path, _campaign.ToString());
    OnSaveSuccess.Invoke();
  }
}

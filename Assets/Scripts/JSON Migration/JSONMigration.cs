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
using SimpleFileBrowser;

public class JSONMigration : MonoBehaviour
{
  public UnityEventString OnParseError = new UnityEventString();
  public UnityEvent OnParseSuccess = new UnityEvent();
  public UnityEvent OnSaveSuccess = new UnityEvent();
  JObject _campaign = null;

  public void BrowseForFile() => FileBrowser.ShowLoadDialog(LoadCampaign,
    delegate { },
    false,
    false,
    string.Empty,
    "Select campaign file");

  void LoadCampaign(string[] paths)
  {
    try
    {
      _campaign = JObject.Parse(File.ReadAllText(paths[0]));
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

  public void SaveConvertedFile() => FileBrowser.ShowSaveDialog(paths =>
  {
    File.WriteAllText(paths[0], _campaign.ToString());
    OnSaveSuccess.Invoke();
  },
    OnSaveSuccess.Invoke,
    false,
    false,
    string.Empty,
    "Save campaign file");
}

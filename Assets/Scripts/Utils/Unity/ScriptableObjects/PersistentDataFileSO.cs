using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(menuName = "ScriptableObjects/PersistentDataFileSO")]
public class PersistentDataFileSO : ScriptableObject
{
  [TextArea] public string DefaultContent = string.Empty;
  public string RelativePath = string.Empty;
  public string Path => Application.persistentDataPath + RelativePath;

  void Awake()
  {
    if (File.Exists(Path)) return;
    File.Create(Path).Close(); File.WriteAllText(Path, DefaultContent);
  }
}

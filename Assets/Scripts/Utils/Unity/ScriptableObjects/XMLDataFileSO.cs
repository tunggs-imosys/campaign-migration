using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

[CreateAssetMenu(menuName = "ScriptableObjects/XMLDataFileSO")]
public class XMLDataFileSO : ScriptableObject
{
  public PersistentDataFileSO File = null;
  public XmlDocument Document = new XmlDocument();

  void OnEnable() => Document.Load(File.Path);

  public void Save() => Document.Save(File.Path);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchEventString : MonoBehaviour
{
  public EventStringSO Source = null;
  public SerializableDictionaryStringUnityEvent Events
    = new SerializableDictionaryStringUnityEvent();

  void Awake() => Source.Listeners += Branch;

  void OnDestroy() => Source.Listeners -= Branch;

  void Branch(string value)
  {
    if (!Events.ContainsKey(value)) return;
    Events[value].Invoke();
  }
}

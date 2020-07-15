using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchEventBool : MonoBehaviour
{
  public EventBoolSO Source = null;
  public SerializableDictionaryBoolUnityEvent Events
    = new SerializableDictionaryBoolUnityEvent();

  void Awake() => Source.Listeners += Branch;

  void OnDestroy() => Source.Listeners -= Branch;

  void Branch(bool value)
  {
    if (!Events.ContainsKey(value)) return;
    Events[value].Invoke();
  }
}

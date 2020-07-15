using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utils;

public class BranchEventFloat : MonoBehaviour
{
  public EventFloatSO Source = null;
  public SerializableDictionaryRangedFloatUnityEvent Events
    = new SerializableDictionaryRangedFloatUnityEvent();

  void Awake() => Source.Listeners += Branch;

  void OnDestroy() => Source.Listeners -= Branch;

  void Branch(float value) => Events.Where(p => value.InRange(p.Key))
    .ForEach(p => p.Value.Invoke());
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFloatInstance : MonoBehaviour
{
  public EventFloatSO Source = null;
  public UnityEventFloat Event = new UnityEventFloat();

  void Awake() => Source.Listeners += Event.Invoke;

  void OnDestroy() => Source.Listeners += Event.Invoke;
}

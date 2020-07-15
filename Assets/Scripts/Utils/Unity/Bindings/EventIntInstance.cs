using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventIntInstance : MonoBehaviour
{
  public EventIntSO Source = null;
  public UnityEventInt Event = new UnityEventInt();

  void Awake() => Source.Listeners += Event.Invoke;

  void OnDestroy() => Source.Listeners += Event.Invoke;
}

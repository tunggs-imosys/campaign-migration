using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInstance : MonoBehaviour
{
  public EventSO Source = null;
  public UnityEvent Event = new UnityEvent();

  void Awake() => Source.Listeners += Event.Invoke;

  void OnDestroy() => Source.Listeners += Event.Invoke;
}

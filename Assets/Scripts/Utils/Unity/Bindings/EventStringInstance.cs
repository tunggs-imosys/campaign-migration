using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStringInstance : MonoBehaviour
{
  public EventStringSO Source = null;
  public UnityEventString Event = new UnityEventString();

  void Awake() => Source.Listeners += Event.Invoke;

  void OnDestroy() => Source.Listeners += Event.Invoke;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTransformsIntance : MonoBehaviour
{
  public EventTransformsSO Source = null;
  public UnityEventTransforms Event = new UnityEventTransforms();

  void Awake() => Source.Listeners += Event.Invoke;

  void OnDestroy() => Source.Listeners += Event.Invoke;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBoolInstance : MonoBehaviour
{
  public EventBoolSO Source = null;
  public UnityEventBool Event = new UnityEventBool();

  void Awake() => Source.Listeners += Event.Invoke;

  void OnDestroy() => Source.Listeners += Event.Invoke;
}

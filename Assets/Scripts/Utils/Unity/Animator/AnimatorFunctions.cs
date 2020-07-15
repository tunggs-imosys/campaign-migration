using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;
using MyBox;

public class AnimatorFunctions : ExtensionBehaviour<Animator>
{
  public SerializableDictionaryStringUnityEvent OnAnimationEvents
    = new SerializableDictionaryStringUnityEvent();

  public void InvokeAnimationEvent(string eventKey)
  {
    if (!OnAnimationEvents.ContainsKey(eventKey)) return;
    OnAnimationEvents[eventKey].Invoke();
  }
}

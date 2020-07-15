using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedAction : MonoBehaviour
{
  float _delaySeconds = 0f;
  UnityAction _action;

  void Start()
  {
    gameObject.name = "Delayed Action Caller";
    StartCoroutine(DelayedCall());
  }

  IEnumerator DelayedCall()
  {
    yield return new WaitForSeconds(_delaySeconds);
    _action();
    Destroy(gameObject);
    yield break;
  }

  public DelayedAction Call(UnityAction action, float delaySeconds)
  {
    _action = action;
    _delaySeconds = delaySeconds;
    return this;
  }
}

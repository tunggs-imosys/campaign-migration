using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class OnPointerHeld : MonoBehaviour,
  IPointerDownHandler,
  IPointerUpHandler
{
  public float HoldSeconds = 0f;
  public UnityEvent Events = new UnityEvent();

  public void OnPointerDown(PointerEventData eventData) =>
    StartCoroutine(WaitAndExecute());

  public void OnPointerUp(PointerEventData eventData) => StopAllCoroutines();

  IEnumerator WaitAndExecute()
  {
    yield return new WaitForSeconds(HoldSeconds);
    Events.Invoke();
    yield break;
  }
}
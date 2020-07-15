using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

public class PlaceObjectUnderPointerOnClick : ExtensionBehaviour<RectTransform>,
  IPointerDownHandler
{
  [SerializeField] RectTransform Target = null;

  public void OnPointerDown(PointerEventData eventData)
  {
    if (Target.gameObject.activeSelf) return;
    Target.anchoredPosition = BaseComp
      .LocalPointFromPointer(eventData.pressPosition);
  }
}

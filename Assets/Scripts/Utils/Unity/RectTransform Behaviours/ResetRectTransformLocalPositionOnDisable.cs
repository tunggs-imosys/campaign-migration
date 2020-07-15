using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRectTransformLocalPositionOnDisable :
  ExtensionBehaviour<RectTransform>
{
  [SerializeField] Vector3 ResetValue = Vector3.zero;

  void OnDisable() => BaseComp.localPosition = ResetValue;
}

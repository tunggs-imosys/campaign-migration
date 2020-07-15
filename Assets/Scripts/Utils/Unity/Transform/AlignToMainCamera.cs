using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlignToMainCamera : MonoBehaviour
{
  Camera _mainCamera = null;

  void OnEnable() => _mainCamera = Camera.main;

  void FixedUpdate()
  {
    if (!transform.hasChanged) return;
    transform.rotation = _mainCamera.transform.rotation;
  }
}

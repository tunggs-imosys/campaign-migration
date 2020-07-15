using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/EventFloatSO")]
public class EventFloatSO : ScriptableObject
{
  public Action<float> Listeners = delegate { };

  public void Invoke(float value) => Listeners(value);
}

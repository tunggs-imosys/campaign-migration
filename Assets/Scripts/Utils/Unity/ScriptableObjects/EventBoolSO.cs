using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/EventBoolSO")]
public class EventBoolSO : ScriptableObject
{
  public Action<bool> Listeners = delegate { };

  public void Invoke(bool value) => Listeners(value);
}

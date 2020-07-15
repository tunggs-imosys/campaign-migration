using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/EventIntSO")]
public class EventIntSO : ScriptableObject
{
  public Action<int> Listeners = delegate { };

  public void Invoke(int value) => Listeners(value);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MyBox;

[CreateAssetMenu(menuName = "ScriptableObjects/EventSO")]
public class EventSO : ScriptableObject
{
  public Action Listeners = delegate { };

  [ButtonMethod] public void Invoke() => Listeners();
}

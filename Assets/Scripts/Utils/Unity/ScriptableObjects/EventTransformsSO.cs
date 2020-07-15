using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/EventTransformsSO")]
public class EventTransformsSO : ScriptableObject
{
  public Action<IEnumerable<Transform>> Listeners = delegate { };

  public void Invoke(IEnumerable<Transform> value) => Listeners(value);
}

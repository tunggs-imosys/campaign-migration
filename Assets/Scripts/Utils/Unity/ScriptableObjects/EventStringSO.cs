using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ScriptableObjects/EventStringSO")]
public class EventStringSO : ScriptableObject
{
  public Action<string> Listeners = delegate { };

  public void Invoke(string value) => Listeners(value);

  public void Invoke(VariableString variable) => Listeners(variable.Value);
}

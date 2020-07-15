using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EventStringLatchSO")]
public class EventStringLatchSO : ScriptableObject
{
  public int CountdownStart = 1;
  public int CurrentCountdown = 1;
  public EventStringSO OnConditionMet = null;

  public void Signal(string value)
  { if (--CurrentCountdown == 0) OnConditionMet.Listeners(value); }

  public void Reset() => CurrentCountdown = CountdownStart;

  public void Reset(int newCountdown)
  { CountdownStart = newCountdown; Reset(); }
}

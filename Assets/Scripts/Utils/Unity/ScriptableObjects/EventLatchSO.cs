using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EventLatchSO")]
public class EventLatchSO : ScriptableObject
{
  public int CountdownStart = 1;
  public int CurrentCountdown = 1;
  public EventSO OnConditionMet = null;

  public void Signal()
  { if (--CurrentCountdown == 0) OnConditionMet.Listeners(); }

  public void Reset() => CurrentCountdown = CountdownStart;

  public void Reset(int newCountdown)
  { CountdownStart = newCountdown; Reset(); }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using System.Linq;

public class TriggerLatch : MonoBehaviour
{
  public int CountdownStart = 1;
  int _currentCountdown = 1;
  public UnityEvent OnConditionMet = new UnityEvent();

  void Awake() => Reset();

  public void Signal()
  { if (--_currentCountdown == 0) OnConditionMet.Invoke(); }

  public void Reset() => _currentCountdown = CountdownStart;

  public void Reset(int newCountdown)
  { CountdownStart = newCountdown; Reset(); }
}

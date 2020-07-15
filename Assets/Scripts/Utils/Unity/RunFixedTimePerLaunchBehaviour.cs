using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RunFixedTimePerLaunchBehaviour : MonoBehaviour
{
  [SerializeField] short RunTimesPerGameLaunch = 1;
  short _timesRan = 0;
  protected UnityEvent AwakeEvent = new UnityEvent();
  protected UnityEvent EnableEvent = new UnityEvent();
  protected UnityEvent StartEvent = new UnityEvent();

  void Awake()
  {
    if (_timesRan == RunTimesPerGameLaunch) return;
    AwakeEvent.Invoke();
  }

  void OnEnable()
  {
    if (_timesRan == RunTimesPerGameLaunch) return;
    EnableEvent.Invoke();
  }

  void Start()
  {
    if (_timesRan == RunTimesPerGameLaunch) return;
    StartEvent.Invoke();
    ++_timesRan;
  }
}

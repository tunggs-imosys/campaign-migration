using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoBehaviourEvents : MonoBehaviour
{
  [SerializeField] UnityEvent AwakeEvent = new UnityEvent();
  [SerializeField] UnityEvent OnEnableEvent = new UnityEvent();
  [SerializeField] UnityEvent StartEvent = new UnityEvent();
  [SerializeField] UnityEvent OnDisableEvent = new UnityEvent();
  [SerializeField] UnityEvent OnDestroyEvent = new UnityEvent();

  void Awake() => AwakeEvent.Invoke();

  void OnEnable() => OnEnableEvent.Invoke();

  void Start() => StartEvent.Invoke();

  void OnDisable() => OnDisableEvent.Invoke();

  void OnDestroy() => OnDestroyEvent.Invoke();
}

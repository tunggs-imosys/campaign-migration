using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PromiseBehaviour<ErrorT, ReturnT> : MonoBehaviour
{
  protected Action<ErrorT> ErrorEvent = error => { };
  protected Action<ReturnT> ThenEvent = result => { };

  void Start() => StartCoroutine(Wait());

  protected abstract IEnumerator Wait();

  public PromiseBehaviour<ErrorT, ReturnT> IfError(Action<ErrorT> errorResolver)
  {
    ErrorEvent += errorResolver;
    return this;
  }

  public PromiseBehaviour<ErrorT, ReturnT> Then(
    Action<ReturnT> responseConsumer)
  {
    ThenEvent += responseConsumer;
    return this;
  }
}

public abstract class PromiseBehaviour : MonoBehaviour
{
  protected Action ErrorEvent = delegate { };
  protected Action ThenEvent = delegate { };

  protected virtual void OnEnable() => StartCoroutine(Wait());

  protected abstract IEnumerator ProcessWaitAction();

  IEnumerator Wait()
  {
    yield return StartCoroutine(ProcessWaitAction());
    ThenEvent();
    ThenEvent = delegate { };
    yield break;
  }

  public PromiseBehaviour IfError(Action errorResolver)
  {
    ErrorEvent += errorResolver;
    return this;
  }

  public PromiseBehaviour Then(Action thenAction)
  {
    ThenEvent += thenAction;
    return this;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.Events;

public class TestScript : MonoBehaviour
{
  public UnityEvent CustomAction = new UnityEvent();

  [ButtonMethod] public void DoCustomAction() => CustomAction.Invoke();
}

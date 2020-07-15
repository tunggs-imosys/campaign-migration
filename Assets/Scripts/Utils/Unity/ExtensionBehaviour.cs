using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MyBox;

public class ExtensionBehaviour<T> : MonoBehaviour
{[AutoProperty] public T BaseComp; }

public class RuntimeExtensionBehaviour<T> : ExtensionBehaviour<T>
{ protected virtual void Awake() => BaseComp = GetComponent<T>(); }

public class ExtensionBehaviour<T1, T2> : MonoBehaviour
{
  [AutoProperty] public T1 BaseComp1;
  [AutoProperty] public T2 BaseComp2;
}
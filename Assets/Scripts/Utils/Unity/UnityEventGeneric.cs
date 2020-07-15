using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using System.Linq;
using TMPro;

[Serializable] public class UnityEventObject : UnityEvent<object> { }

[Serializable] public class UnityEventString : UnityEvent<string> { }
[Serializable] public class UnityEventInt : UnityEvent<int> { }

[Serializable] public class UnityEventBool : UnityEvent<bool> { }

[Serializable] public class UnityEventFloat : UnityEvent<float> { }

[Serializable]
public class UnityEventStrings : UnityEvent<IEnumerable<string>> { }

[Serializable]
public class UnityEventTuples2Int
  : UnityEvent<IEnumerable<ValueTuple<int, int>>>
{ }

[Serializable] public class UnityEventCollider2D : UnityEvent<Collider2D> { }

[Serializable] public class UnityEventCollision2D : UnityEvent<Collision2D> { }

[Serializable]
public class UnityEventTransforms : UnityEvent<IEnumerable<Transform>> { }
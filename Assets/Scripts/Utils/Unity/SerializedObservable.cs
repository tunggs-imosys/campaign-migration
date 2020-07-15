using System;
using UnityEngine.Events;
using UnityEngine;

[Serializable]
public class SerializedObservable<T>
{
  [SerializeField] protected T _value = default(T);
  public virtual T Value
  {
    get => _value;
    set
    {
      T oldValue = _value;
      bool hasChange = true;
      if (oldValue != null) hasChange = !oldValue.Equals(value);
      _value = value;
      if (hasChange) OnChange.Invoke(value);
    }
  }
  public Action<T> OnChange = delegate { };

  public static implicit operator T(SerializedObservable<T> c) => c.Value;

  public SerializedObservable(T initialValue) => _value = initialValue;
}

[Serializable]
public class SerializedObservableBool : SerializedObservable<bool>
{
  public UnityEvent OnTrue = new UnityEvent();
  public UnityEvent OnFalse = new UnityEvent();

  public SerializedObservableBool(bool initialValue) : base(initialValue)
  {
    OnChange += value => (value ? OnTrue : OnFalse).Invoke();
  }
}
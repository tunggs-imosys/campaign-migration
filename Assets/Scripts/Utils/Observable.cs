using System;

[Serializable]
public class Observable<T>
{
  protected T _value = default(T);
  public virtual T Value
  {
    get => _value;
    set
    {
      T oldValue = _value;
      bool hasChange = !oldValue.Equals(value);
      _value = value;
      if (hasChange) OnChange(oldValue, value);
    }
  }
  public Action<T, T> OnChange = delegate { };

  public static implicit operator T(Observable<T> c) => c.Value;

  public static readonly Observable<T> Default = new Observable<T>(default(T));

  public Observable(T initialValue) => _value = initialValue;
}

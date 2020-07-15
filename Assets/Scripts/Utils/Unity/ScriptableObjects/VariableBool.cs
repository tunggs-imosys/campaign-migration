using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using Utils;
using UnityEditor;

[CreateAssetMenu(menuName = "ScriptableObjects/VariableBool")]
public class VariableBool : ScriptableObject
{
  [SerializeField] protected bool _value = false;
  public bool Value
  {
    get => _value;
    set
    {
      var oldValue = _value;
      bool hasChange = !oldValue.Equals(value);
      _value = value;
      if (hasChange) OnChange?.Listeners.Invoke(value);
    }
  }
  public EventBoolSO OnChange = null;

  public void Set(VariableBool variable) => Value = variable.Value;

  public void SetWithoutEvent(bool value) => _value = value;

  [ButtonMethod]
  public void GenerateEvent()
  {
    if (OnChange != null) return;
    OnChange = ScriptableObject.CreateInstance<EventBoolSO>();
    OnChange.name = "OnChange";
    AssetDatabase.AddObjectToAsset(OnChange, this.GetPath());
    AssetDatabase.ImportAsset(this.GetPath());
  }
}

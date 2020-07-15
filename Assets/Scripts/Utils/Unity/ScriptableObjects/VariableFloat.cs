using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using Utils;
using UnityEditor;

[CreateAssetMenu(menuName = "ScriptableObjects/VariableFloat")]
public class VariableFloat : ScriptableObject
{
  [SerializeField] protected float _value = 0;
  public float Value
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
  public EventFloatSO OnChange = null;

  public VariableFloat(float initial) => _value = initial;

  public void Set(VariableFloat variable) => Value = variable.Value;

  [ButtonMethod]
  public void GenerateEvent()
  {
    if (OnChange != null) return;
    OnChange = ScriptableObject.CreateInstance<EventFloatSO>();
    OnChange.name = "OnChange";
    AssetDatabase.AddObjectToAsset(OnChange, this.GetPath());
    AssetDatabase.ImportAsset(this.GetPath());
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using Utils;
using UnityEditor;

[CreateAssetMenu(menuName = "ScriptableObjects/VariableInt")]
public class VariableInt : ScriptableObject
{
  [SerializeField] protected int _value = 0;
  public int Value
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
  public EventIntSO OnChange = null;

  public void Set(VariableInt variable) => Value = variable.Value;

  [ButtonMethod]
  public void GenerateEvent()
  {
    if (OnChange != null) return;
    OnChange = ScriptableObject.CreateInstance<EventIntSO>();
    OnChange.name = "OnChange";
    AssetDatabase.AddObjectToAsset(OnChange, this.GetPath());
    AssetDatabase.ImportAsset(this.GetPath());
  }
}

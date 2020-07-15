using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using Utils;
using UnityEditor;

[CreateAssetMenu(menuName = "ScriptableObjects/VariableString")]
public class VariableString : ScriptableObject
{
  [SerializeField] protected string _value = string.Empty;
  public string Value
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
  public EventStringSO OnChange = null;

  public void Set(VariableString variable) => Value = variable.Value;

  [ButtonMethod]
  public void GenerateEvent()
  {
    if (OnChange != null) return;
    OnChange = ScriptableObject.CreateInstance<EventStringSO>();
    OnChange.name = "OnChange";
    AssetDatabase.AddObjectToAsset(OnChange, this.GetPath());
    AssetDatabase.ImportAsset(this.GetPath());
  }
}

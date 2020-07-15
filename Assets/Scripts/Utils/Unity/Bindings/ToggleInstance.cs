using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInstance : ExtensionBehaviour<Toggle>
{
  public ToggleSO Source = null;

  void Awake() => Source.Value = BaseComp;
}

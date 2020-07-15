using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Button))]
public class ButtonFunctions : ExtensionBehaviour<Button>
{
  public void Click() => BaseComp.onClick.Invoke();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFunctions : ExtensionBehaviour<Image>
{
  public VariableFloat BaseFullVariable = null;

  public void SetFillOnBaseFull(float value) =>
    BaseComp.fillAmount = value / BaseFullVariable.Value;
}

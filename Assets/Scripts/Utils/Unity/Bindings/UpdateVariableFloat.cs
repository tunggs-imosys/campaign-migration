using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpdateVariableFloat : MonoBehaviour
{
  public VariableFloat Target = null;
  public float Factors = 0f;

  void Update() => Target.Value += Factors * Time.deltaTime;
}

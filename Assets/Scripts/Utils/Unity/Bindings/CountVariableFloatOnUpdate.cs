using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountVariableFloatOnUpdate : MonoBehaviour
{
  public VariableFloat Source = null;
  public float DeltaMultiplier = 1f;

  void Update() => Source.Value += Time.smoothDeltaTime * DeltaMultiplier;
}

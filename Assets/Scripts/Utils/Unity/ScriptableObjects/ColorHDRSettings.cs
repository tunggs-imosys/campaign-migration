using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ColorHDRSettings")]
public class ColorHDRSettings : ScriptableObject
{
  [ColorUsage(true, true)] public Color Value = Color.white;
}

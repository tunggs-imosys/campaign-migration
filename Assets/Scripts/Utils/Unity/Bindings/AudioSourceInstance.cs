using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceInstance : ExtensionBehaviour<AudioSource>
{
  public AudioSourceSO Source = null;

  void Awake() => Source.Value = BaseComp;
}

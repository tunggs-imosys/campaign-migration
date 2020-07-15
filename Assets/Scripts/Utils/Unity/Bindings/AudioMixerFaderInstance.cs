using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMixerFaderInstance : MonoBehaviour
{
  public AudioMixerFader Source = null;
  void Awake() => Source.Instance = this;
}

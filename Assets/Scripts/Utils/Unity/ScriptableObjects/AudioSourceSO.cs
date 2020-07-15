using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioSourceSO")]
public class AudioSourceSO : ScriptableObject
{
  public AudioSource Value = null;

  public void SetClip(AudioClip clip)
  {
    Value.Stop();
    Value.clip = clip;
    Value.Play();
  }
}

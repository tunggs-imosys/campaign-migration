using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioSourcePoolSO")]
public class AudioSourcePoolSO : ScriptableObject
{
  public AudioSourcePool Value = null;

  public void PlayClip(Vector3 audioPosition, AudioClip clip)
  {
    var source = Value.GetFirst(s => !s.isPlaying);
    source.transform.position = audioPosition;
    source.clip = clip;
    source.Play();
  }

  public void PlayClip(AudioClip clip) =>
    PlayClip(Value.transform.position, clip);

  public void PlayClipIgnoreSpace(AudioClip clip)
  {
    var source = Value.GetFirst(s => !s.isPlaying);
    source.clip = clip;
    source.Play();
  }
}

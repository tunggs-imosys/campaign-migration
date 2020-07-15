using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEmitter : MonoBehaviour
{
  public AudioSourcePoolSO SourcePool = null;

  public void PlayClip(AudioClip clip) => SourcePool
    .PlayClip(transform.position, clip);
}

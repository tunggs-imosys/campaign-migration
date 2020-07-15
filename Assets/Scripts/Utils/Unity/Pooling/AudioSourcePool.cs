using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioSourcePool : ObjectPool<AudioSource>
{
  public AudioSourcePoolSO Source = null;

  protected override void Awake()
  {
    base.Awake();
    if (Source != null) Source.Value = this;
  }
}

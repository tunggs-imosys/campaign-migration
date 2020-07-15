using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using MyBox;

public class ParticleSystemPool : ObjectPool<ParticleSystem>
{
  public ParticleSystemPoolSO Source = null;

  protected override void Awake()
  {
    base.Awake();
    if (Source != null) Source.Value = this;
  }
}

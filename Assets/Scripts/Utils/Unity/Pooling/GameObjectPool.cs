using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : ObjectPool<GameObject>
{
  public GameObjectPoolSO Source = null;

  protected override void Awake()
  {
    base.Awake();
    if (Source != null) Source.Value = this;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using Utils;

public class SpriteSelection : ExtensionBehaviour<SpriteRenderer, SpriteMask>
{
  public SpriteRenderer BoundSprite = null;
  public float Padding = 0f;
  public float OutlineThickness = 0f;

  [ButtonMethod]
  public void Bind()
  {
    transform.position = BoundSprite.transform.position;
    transform.localScale = BoundSprite.bounds.extents.magnitude
      .Multiply(Vector3.one * 2)
      .Plus(Padding);
    BaseComp1.transform.localScale = BaseComp2.transform.localScale
      .Plus(OutlineThickness);
  }

  public SpriteSelection Bind(SpriteRenderer sprite)
  {
    BoundSprite = sprite;
    transform.position = BoundSprite.transform.position;
    transform.localScale = BoundSprite.bounds.extents.magnitude
      .Multiply(Vector3.one * 2)
      .Plus(Padding);
    BaseComp1.transform.localScale = BaseComp2.transform.localScale
      .Plus(OutlineThickness);
    return this;
  }
}

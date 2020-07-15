using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using System.Linq;
using Utils;

public class Collision2DEvents : MonoBehaviour
{
  [Tag] public string[] ApplicableTags = new string[0];
  public RangedFloat ApplicableRelativeVelocity
    = new RangedFloat(float.MinValue, float.MaxValue);

  [SerializeField]
  UnityEventCollision2D OnCollisionEnter2DEvent = new UnityEventCollision2D();
  [SerializeField]
  UnityEventCollision2D OnCollisionExit2DEvent = new UnityEventCollision2D();
  [SerializeField]
  UnityEventCollision2D OnCollisionStay2DEvent = new UnityEventCollision2D();

  void OnCollisionEnter2D(Collision2D other)
  {
    if (!ApplicableTags.Contains(other.gameObject.tag)) return;
    if (!other.relativeVelocity.magnitude.InRange(ApplicableRelativeVelocity))
      return;
    OnCollisionEnter2DEvent.Invoke(other);
  }

  void OnCollisionExit2D(Collision2D other)
  {
    if (!ApplicableTags.Contains(other.gameObject.tag)) return;
    if (!other.relativeVelocity.magnitude.InRange(ApplicableRelativeVelocity))
      return;
    OnCollisionExit2DEvent.Invoke(other);
  }

  void OnCollisionStay2D(Collision2D other)
  {
    if (!ApplicableTags.Contains(other.gameObject.tag)) return;
    if (!other.relativeVelocity.magnitude.InRange(ApplicableRelativeVelocity))
      return;
    OnCollisionStay2DEvent.Invoke(other);
  }
}

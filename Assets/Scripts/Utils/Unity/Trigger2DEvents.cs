using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using System.Linq;
using Utils;

public class Trigger2DEvents : MonoBehaviour
{
  [Tag] public string[] ApplicableTags = new string[0];

  [SerializeField]
  UnityEventCollider2D OnTriggerEnter2DEvent = new UnityEventCollider2D();
  [SerializeField]
  UnityEventCollider2D OnTriggerExit2DEvent = new UnityEventCollider2D();
  [SerializeField]
  UnityEventCollider2D OnTriggerStay2DEvent = new UnityEventCollider2D();

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!ApplicableTags.Contains(other.tag)) return;
    OnTriggerEnter2DEvent.Invoke(other);
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (!ApplicableTags.Contains(other.tag)) return;
    OnTriggerExit2DEvent.Invoke(other);
  }

  void OnTriggerStay2D(Collider2D other)
  {
    if (!ApplicableTags.Contains(other.tag)) return;
    OnTriggerStay2DEvent.Invoke(other);
  }
}

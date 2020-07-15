using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class AnimatorMatchTarget : ExtensionBehaviour<Animator>
{
  public string StateName = string.Empty;
  public int LayerIndex = 0;
  public Transform Target = null;
  public Vector3 MatchPosition = Vector3.zero;
  public Quaternion MatchRotation = Quaternion.LookRotation(Vector3.forward,
    Vector3.up);
  public AvatarTarget TargetBodyPart = AvatarTarget.Root;
  public Vector3 PositionWeight = Vector3.one;
  [Range(-1f, 1f)] public float RotationWeight = 1f;
  [PositiveValueOnly] public float StartNormalizedTime = 0f;
  [PositiveValueOnly] public float TargetNormalizedTime = 1f;

  bool _isMatchingStateRunning => BaseComp
    .GetCurrentAnimatorStateInfo(LayerIndex).IsName(StateName);

  void Awake() => enabled = false;

  void FixedUpdate()
  {
    if (!_isMatchingStateRunning) return;

    BaseComp.MatchTarget(Target.position,
      Target.rotation,
      TargetBodyPart,
      new MatchTargetWeightMask(PositionWeight, RotationWeight),
      StartNormalizedTime,
      TargetNormalizedTime);
  }
}

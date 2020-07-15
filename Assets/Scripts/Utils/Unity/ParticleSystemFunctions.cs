using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleSystemFunctions : ExtensionBehaviour<ParticleSystem>
{
  public ParticleSystem.EmissionModule Emission;
  public ParticleSystem.ShapeModule Shape;
  public ParticleSystem.VelocityOverLifetimeModule VelocityOverLifetime;
  public ParticleSystem.LimitVelocityOverLifetimeModule LimitVelocityOverLifetime;
  public ParticleSystem.InheritVelocityModule InheritVelocity;
  public ParticleSystem.ForceOverLifetimeModule ForceOverLifetime;
  public ParticleSystem.ColorOverLifetimeModule ColorOverLifetime;
  public ParticleSystem.ColorBySpeedModule ColorBySpeed;
  public ParticleSystem.SizeOverLifetimeModule SizeOverLifetime;
  public ParticleSystem.SizeBySpeedModule SizeBySpeed;
  public ParticleSystem.RotationOverLifetimeModule RotationOverLifetime;
  public ParticleSystem.RotationBySpeedModule RotationBySpeed;
  public ParticleSystem.ExternalForcesModule ExternalForces;
  public ParticleSystem.NoiseModule Noise;
  public ParticleSystem.CollisionModule Collision;
  public ParticleSystem.TriggerModule Trigger;
  public ParticleSystem.SubEmittersModule SubEmitters;
  public ParticleSystem.TextureSheetAnimationModule TextureSheetAnimation;
  public ParticleSystem.LightsModule Lights;
  public ParticleSystem.TrailModule Trails;
  public ParticleSystem.CustomDataModule CustomData;
  public UnityEvent OnStop = new UnityEvent();

  void Awake()
  {
    Emission = BaseComp.emission;
    Shape = BaseComp.shape;
    VelocityOverLifetime = BaseComp.velocityOverLifetime;
    LimitVelocityOverLifetime = BaseComp.limitVelocityOverLifetime;
    InheritVelocity = BaseComp.inheritVelocity;
    ForceOverLifetime = BaseComp.forceOverLifetime;
    ColorOverLifetime = BaseComp.colorOverLifetime;
    ColorBySpeed = BaseComp.colorBySpeed;
    SizeOverLifetime = BaseComp.sizeOverLifetime;
    SizeBySpeed = BaseComp.sizeBySpeed;
    RotationOverLifetime = BaseComp.rotationOverLifetime;
    RotationBySpeed = BaseComp.rotationBySpeed;
    ExternalForces = BaseComp.externalForces;
    Noise = BaseComp.noise;
    Collision = BaseComp.collision;
    Trigger = BaseComp.trigger;
    SubEmitters = BaseComp.subEmitters;
    TextureSheetAnimation = BaseComp.textureSheetAnimation;
    Lights = BaseComp.lights;
    Trails = BaseComp.trails;
    CustomData = BaseComp.customData;
  }

  void OnParticleSystemStopped() => OnStop.Invoke();

  public void ToggleEmission(bool state) => Emission.enabled = state;

  public void Emit(int count) => BaseComp.Emit(count);
}

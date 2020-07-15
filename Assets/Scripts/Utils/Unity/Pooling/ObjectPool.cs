using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utils;
using MyBox;
using System;

public class ObjectPool<T> : MonoBehaviour where T : UnityEngine.Object
{
  public T Prefab = null;
  public int PreCreatedNumber = 0;
  [PositiveValueOnly] public int GrowStep = 1;
  public Queue<T> Instances = new Queue<T>();

  protected virtual void Awake() => this.Create(PreCreatedNumber);
}

public static class ObjectPoolExtensions
{
  public static IEnumerable<T> Create<T>(this ObjectPool<T> source, int number)
    where T : UnityEngine.Object
  {
    var newInstances = Enumerable.Empty<T>();
    for (int i = number; i > 0; --i)
    {
      var newInstance = UnityEngine.Object.Instantiate(source.Prefab,
        source.transform);
      newInstances = newInstances.Append(newInstance);
    }
    newInstances.ForEach(source.Instances.Enqueue);
    return newInstances;
  }

  public static IEnumerable<T> CreateByStep<T>(this ObjectPool<T> source,
    int stepNumber) where T : UnityEngine.Object =>
    source.Create(source.GrowStep * stepNumber);

  public static IEnumerable<T> Get<T>(this ObjectPool<T> source,
    Func<T, bool> condition,
    int number = 1) where T : UnityEngine.Object
  {
    int matchedCount = 0;
    var matchedInstances = Enumerable.Empty<T>();
    for (int remainingCount = source.Instances.Count;
      remainingCount >= number;
      --remainingCount)
    {
      var matchedInstance = source.Instances.Dequeue();
      source.Instances.Enqueue(matchedInstance);
      if (condition(matchedInstance))
      {
        matchedInstances = matchedInstances.Append(matchedInstance);
        ++matchedCount;
      }
      if (matchedCount == number) return matchedInstances;
    }
    var stepsToGrow = Mathf.CeilToInt(number.CastTo<float>() / source.GrowStep);
    return source.CreateByStep(stepsToGrow).Take(number);
  }

  public static T GetFirst<T>(this ObjectPool<T> source,
    Func<T, bool> condition) where T : UnityEngine.Object
  {
    int matchedCount = source.Instances.Count;
    T matchedInstance = null;
    do
    {
      matchedInstance = source.Instances.Dequeue();
      source.Instances.Enqueue(matchedInstance);
      if (condition(matchedInstance)) return matchedInstance;
      else --matchedCount;
    } while (matchedCount > 0);
    return source.CreateByStep(1).First();
  }
}
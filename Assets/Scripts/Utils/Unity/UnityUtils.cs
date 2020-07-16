using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;
using MyBox;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

namespace Utils
{
  public static partial class UnityFunctions
  {
    public static GameObject SetName(this GameObject source, string name)
    {
      source.name = name;
      return source;
    }

    public static T SetPosition<T>(this T source, Vector3 position)
      where T : Component
    {
      source.transform.position = position;
      return source;
    }

    // public static ResolveUnityWebRequest Resolve(this UnityWebRequest source,
    //   string nameForResolver = "WebRequest Resolver") =>
    //   new GameObject().SetName(nameForResolver)
    //     .AddComponent<ResolveUnityWebRequest>()
    //     .SetRequest(source);

    public static Vector3 To(this Vector3 source, Vector3 target) =>
      target - source;

    public static Vector2 To(this Vector2 source, Vector2 target) =>
      target - source;

    public static float DistanceTo(this Component source, Component target) =>
      source.transform.position.To(target.transform.position).magnitude;

    public static float SignedAngleTo(this Vector2 from, Vector2 to) =>
      Vector2.SignedAngle(from, to);

    public static float SignedAngleTo(this Vector3 from, Vector2 to) =>
      Vector2.SignedAngle(from, to);

    public static Quaternion SetEulerZ(this Quaternion source, float z) =>
      Quaternion.Euler(source.eulerAngles.x, source.eulerAngles.y, z);

    public static IEnumerable<Scene> GetScenes()
    {
      var scenes = Enumerable.Empty<Scene>();
      for (int i = 0; i < SceneManager.sceneCount; ++i)
        scenes = scenes.Append(SceneManager.GetSceneAt(i));
      return scenes;
    }

    public static Vector2 LocalPointFromPointer(this RectTransform source,
      Vector2 pointerPosition)
    {
      var localPoint = Vector2.zero;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(source,
        pointerPosition,
        Camera.main,
        out localPoint);
      return localPoint;
    }

    public static IEnumerable<Transform> SiblingSort(
      this IEnumerable<Transform> source, int siblingIndex)
    {
      source.Reverse().ForEach(t => t.SetSiblingIndex(siblingIndex));
      return source;
    }

    public static int GetRandom(this RangeInt source) => UnityEngine.Random
      .Range(source.start, source.start + source.length);

    public static Vector3 Inverted(this Vector3 source) => source * -1;

    public static Vector3 Plus(this Vector3 source, Vector3 right) =>
      source + right;

    public static Vector3 Plus(this Vector3 source, float right) =>
      source + new Vector3(right, right, right);

    public static Vector3 Plus(this float source, Vector3 vector) =>
      vector + new Vector3(source, source, source);

    public static Vector3 Multiply(this Vector3 source, int right) =>
      source * right;

    public static Vector3 Multiply(this Vector3 source, float right) =>
      source * right;

    public static Vector3 Multiply(this float source, Vector3 right) =>
      source * right;

    public static Vector3 RandomPoint(this Bounds source) => source.center
      + new Vector3(
          UnityEngine.Random.Range(-source.extents.x, source.extents.x),
          UnityEngine.Random.Range(-source.extents.y, source.extents.y),
          UnityEngine.Random.Range(-source.extents.z, source.extents.z));

    public static UnityEvent Once(this UnityEvent source, UnityAction action)
    {
      UnityAction wrapperAction = null;
      wrapperAction = () =>
      {
        source.RemoveListener(action);
        source.RemoveListener(wrapperAction);
        action();
      };
      source.AddListener(wrapperAction);
      return source;
    }

    public static void AddExplosionForce(this Rigidbody2D source,
      float explosionForce,
      Vector3 explosionPosition,
      float explosionRadius,
      float upwardsModifier = 0.0f,
      ForceMode2D mode = ForceMode2D.Force)
    {
      var dir = (source.transform.position - explosionPosition);
      float wearoff = 1 - (dir.magnitude / explosionRadius);
      Vector3 baseForce = dir.normalized * explosionForce * wearoff;
      source.AddForce(baseForce);

      float upliftWearoff = 1 - upwardsModifier / explosionRadius;
      Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
      source.AddForce(upliftForce);
    }

    public static Material SetAlpha(this Material source, float alpha)
    {
      source.color = source.color.WithAlphaSetTo(alpha);
      return source;
    }

    public static float GetPreferredHeight(this TMP_Text source) =>
      LayoutUtility.GetPreferredHeight(source.rectTransform);

    public static string GetPath(this UnityEngine.Object source) =>
      AssetDatabase.GetAssetPath(source);
  }

  [Serializable]
  public class SerializedArrayInt
  { public int[] Values = new int[0]; }

  [Serializable]
  public class SerializedArraySprite
  { public Sprite[] Values = new Sprite[0]; }
}
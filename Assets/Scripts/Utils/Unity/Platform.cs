using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform
{
  public static string Current =
#if UNITY_ANDROID
      "android";
#elif UNITY_IOS
      "ios";
#elif UNITY_WEBGL
      "webgl";
#else
      "webgl";
#endif
}

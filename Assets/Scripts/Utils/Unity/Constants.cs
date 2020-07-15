using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Unity
{
  public static class Constants
  {
    public static WaitForFixedUpdate WaitForFixedUpdate =
      new WaitForFixedUpdate();

    public static WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();

    static Dictionary<float, WaitForSeconds> _cachedWaits
      = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWaitForSeconds(float seconds)
    {
      if (!_cachedWaits.ContainsKey(seconds))
        _cachedWaits.Add(seconds, new WaitForSeconds(seconds));
      return _cachedWaits[seconds];
    }
  }
}

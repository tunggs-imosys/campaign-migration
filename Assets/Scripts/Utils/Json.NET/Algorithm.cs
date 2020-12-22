using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

namespace Utils.Json
{
  public static class Algorithm
  {
    public static JToken GetEnsuredProperty<T>(this JToken source,
      string key,
      JToken defaultValue) where T : JToken
    {
      if (source[key] == null) source[key] = defaultValue;
      return source[key];
    }
  }
}

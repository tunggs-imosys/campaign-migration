using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

namespace Utils.Json
{
  public static class Algorithm
  {
    public static JObject EnsureProperty(this JObject source,
      string key,
      JToken value,
      bool overrideValue = true)
    {
      if (source.ContainsKey(key)) { if (overrideValue) source[key] = value; }
      else source.Add(new JProperty(key, value));
      return source;
    }
  }
}

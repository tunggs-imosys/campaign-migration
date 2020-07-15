using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CacheDependentBehaviour : MonoBehaviour
{
  [SerializeField] string CacheRelativeFilePath = string.Empty;
  protected string CacheContent => File
    .ReadAllText(Application.persistentDataPath + CacheRelativeFilePath);
}

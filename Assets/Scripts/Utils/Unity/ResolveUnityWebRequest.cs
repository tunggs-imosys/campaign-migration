using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using Utils;

[DisallowMultipleComponent]
public class ResolveUnityWebRequest : PromiseBehaviour<string, DownloadHandler>
{
  public UnityWebRequest Request = null;

  protected override IEnumerator Wait()
  {
    yield return Request.SendWebRequest();
    if (Request.isNetworkError || Request.isHttpError)
      ErrorEvent(Request.error);
    else ThenEvent(Request.downloadHandler);
    Request.Dispose();
    Destroy(gameObject);
    yield break;
  }

  public ResolveUnityWebRequest SetRequest(UnityWebRequest request)
  {
    Request = request;
    return this;
  }
}

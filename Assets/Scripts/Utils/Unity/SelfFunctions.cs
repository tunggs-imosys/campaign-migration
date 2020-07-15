using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SelfFunctions : MonoBehaviour
{
  public void DestroySelf() => Destroy(gameObject);

  public void DisableSelf() => gameObject.SetActive(false);

  public void EnableSelf() => gameObject.SetActive(true);

  public void ToggleSelf() => gameObject.SetActive(!gameObject.activeSelf);

  public void LoadSceneAsync(string sceneName) =>
    SceneManager.LoadSceneAsync(sceneName);

  public void EnableSelfDelayed(float seconds) => new GameObject()
    .AddComponent<DelayedAction>()
    .Call(() => gameObject.SetActive(true), seconds);
}

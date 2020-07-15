using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MyBox;

[CreateAssetMenu(menuName = "ScriptableObjects/Engine")]
public class Engine : ScriptableObject
{
  public EventStringLatchSO SceneAddedEventLatch = null;
  public void DebugLog(string msg) => Debug.Log(msg);

  public void DebugLog(object msg) => Debug.Log(msg);

  public void LoadSceneAdditive(string sceneName)
  {
    var sceneToLoad = SceneManager.GetSceneByName(sceneName);
    if (sceneToLoad.isLoaded)
    {
      SceneManager.SetActiveScene(sceneToLoad);
      SceneAddedEventLatch?.Signal(sceneName);
      return;
    }
    SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive)
      .completed += asyncOp =>
      {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        SceneAddedEventLatch?.Signal(sceneName);
      };
  }

  public void UnloadSceneOfObject(Transform t) => SceneManager
    .UnloadSceneAsync(t.gameObject.scene);

  public void DeletePlayerPrefs(string key) => PlayerPrefs.DeleteKey(key);

  public void SetTimeScale(float value) => Time.timeScale = value;
}

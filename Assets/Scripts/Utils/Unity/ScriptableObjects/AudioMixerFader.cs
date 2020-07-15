using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioMixerFader")]
public class AudioMixerFader : ScriptableObject
{
  public AudioMixer Mixer = null;
  public string ParameterName = string.Empty;
  public float Duration = 1f;
  public AudioMixerFaderInstance Instance = null;

  public void StartFade(float targetVolume)
  {
    Instance.StopAllCoroutines();
    Instance.StartCoroutine(Fade(Mixer, ParameterName, Duration, targetVolume));
  }

  public static IEnumerator Fade(AudioMixer mixer,
    string exposedParam,
    float duration,
    float targetVolume)
  {
    float currentTime = 0;
    float currentVol;
    mixer.GetFloat(exposedParam, out currentVol);
    currentVol = Mathf.Pow(10, currentVol / 20);
    float targetValue = Mathf.Clamp(targetVolume, 0, 1);

    while (currentTime < duration)
    {
      currentTime += Time.unscaledDeltaTime;
      float newVol = Mathf.Lerp(currentVol,
        targetValue,
        currentTime / duration);
      mixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
      yield return null;
    }
    yield break;
  }
}

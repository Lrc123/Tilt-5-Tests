using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TurboFade : MonoBehaviour
{
    public float turboFadeTime = 0.2f;
    public float fadeControlRate = 0.01f;

    private bool isTurboFading;
    private float nonTurboPitch;
    public float turboPitch = 1.2f;

    public AudioMixer audioMixer;

    private void Start()
    {
        audioMixer.GetFloat("PitchShift", out nonTurboPitch);
    }

    public void StartTurbo()
    {
        StopAllCoroutines();
        StartCoroutine(TurboFadeIn());
    }

    public void StopTurbo()
    {
        StopAllCoroutines();
        StartCoroutine(TurboFadeOut());
    }

    private IEnumerator TurboFadeIn()
    {
        WaitForSeconds wait = new WaitForSeconds(fadeControlRate);
        float increment = fadeControlRate / turboFadeTime;
        float currentPitch = nonTurboPitch;
        audioMixer.GetFloat("PitchShift", out currentPitch);
        while (currentPitch < turboPitch)
        {
            currentPitch = Mathf.Min(currentPitch + increment, turboPitch);
            audioMixer.SetFloat("PitchShift", currentPitch);
            yield return wait;
        }
    }

    private IEnumerator TurboFadeOut()
    {
        WaitForSeconds wait = new WaitForSeconds(fadeControlRate);
        float increment = fadeControlRate / turboFadeTime;
        float currentPitch = turboPitch;
        audioMixer.GetFloat("PitchShift", out currentPitch);
        while (currentPitch > nonTurboPitch)
        {
            currentPitch = Mathf.Max(currentPitch - increment, nonTurboPitch);
            audioMixer.SetFloat("PitchShift", currentPitch);
            yield return wait;
        }
    }
}

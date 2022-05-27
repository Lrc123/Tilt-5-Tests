using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesFade : MonoBehaviour
{
    public float fadeControlRate = 0.01f;

    private bool isFading;
    [Range(0f, 1f)] public float maxVolume = 1f;

    private int numLeaves = 100;
    public AudioSource leavesAudioSource;
    private float targetVolume;

    private void Start()
    {
        StartCoroutine(AdjustVolume());
    }

    public void UpdateLeaves(int add)
    {
        numLeaves = Mathf.Clamp(numLeaves + add, 0, 100);
        float amount = Mathf.Lerp(0f, 1f, numLeaves / 100f);
        targetVolume = amount;
        Debug.Log(numLeaves + ", " + targetVolume);
    }

    private void Update()
    {
        //numLeaves = Mathf.Max(numLeaves - 1, 0);
    }

    private IEnumerator AdjustVolume()
    {
        while (enabled)
        {
            if (Mathf.Abs(leavesAudioSource.volume - targetVolume) > 0.01f)
            {
                float newVol = targetVolume > leavesAudioSource.volume ? leavesAudioSource.volume + 0.01f : leavesAudioSource.volume - 0.01f;
                newVol = Mathf.Clamp(newVol, 0f, maxVolume);
                leavesAudioSource.volume = newVol;
            }
            yield return new WaitForSeconds(fadeControlRate);
        }
    }
}

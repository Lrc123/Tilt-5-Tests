using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesFade : MonoBehaviour
{
    public float fadeControlRate = 0.01f;
    [Range(0.001f, 0.01f)] public float fadeRate = 0.008f;
    [Range(100, 250)] public int clampNumLeaves = 150;

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
        //print(numLeaves + add);
        numLeaves = Mathf.Clamp(numLeaves + add, 0, 100);
        targetVolume = Mathf.Lerp(0f, maxVolume, numLeaves / 100f);
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

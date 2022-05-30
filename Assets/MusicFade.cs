using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFade : MonoBehaviour
{
    public float musicFadeTime = 0.5f;
    public AudioClip clearClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FadeMusic()
    {
        StartCoroutine(MusicFadeOut());
    }

    private IEnumerator MusicFadeOut()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        float increment = 0.01f / musicFadeTime;

        while (audioSource.volume > 0f)
        {
            audioSource.volume = Mathf.Max(audioSource.volume - increment, 0f);
            yield return wait;
        }
        audioSource.Stop();
        audioSource.volume = 1f;
        audioSource.PlayOneShot(clearClip);
    }
}

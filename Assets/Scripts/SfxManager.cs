using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] bellSounds;
    [SerializeField]
    private AudioClip[] flipperSounds;
    [SerializeField]
    private AudioClip[] scoreSounds;
    public AudioClip jetOnSound;
    public AudioClip jetOffSound;

    public float jetFadeTime = 0.2f;
    public float fadeControlRate = 0.01f;

    private AudioSource audioSource;
    private AudioSource jetAudioSource;

    private bool isJetPlaying;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        jetAudioSource = GetComponentInChildren<AudioSource>();
    }

    public void PlayBumperSound()
    {
        int bellIndex = Random.Range(0, bellSounds.Length);
        int flipperIndex = Random.Range(0, flipperSounds.Length);
        int scoreIndex = Random.Range(0, scoreSounds.Length);

        audioSource.PlayOneShot(bellSounds[bellIndex]);
        audioSource.PlayOneShot(flipperSounds[flipperIndex]);
        audioSource.PlayOneShot(scoreSounds[scoreIndex]);
    }

    public void PlayJetSound()
    {
        StopAllCoroutines();
        StartCoroutine(JetFadeIn());

        //if (!isJetPlaying)
        //{
        //    audioSource.PlayOneShot(jetOnSound);
        //    StopAllCoroutines();
        //    StartCoroutine(DelayJetLoop());
        //    isJetPlaying = true;
        //}
    }

    public void StopJetSound()
    {
        StopAllCoroutines();
        StartCoroutine(JetFadeOut());

        //if (isJetPlaying)
        //{
        //    audioSource.PlayOneShot(jetOffSound);
        //    jetAudioSource.Stop();
        //    StopAllCoroutines();
        //    isJetPlaying = false;
        //}
    }

    private IEnumerator JetFadeIn()
    {
        if (!jetAudioSource.isPlaying)
        {
            jetAudioSource.volume = 0f;
            jetAudioSource.pitch = 0.5f;
            jetAudioSource.Play();
        }

        WaitForSeconds wait = new WaitForSeconds(fadeControlRate);

        float increment = fadeControlRate / jetFadeTime;

        while (jetAudioSource.volume < 1f)
        {
            jetAudioSource.volume = Mathf.Min(jetAudioSource.volume + 0.05f, 1f);
            jetAudioSource.pitch = Mathf.Min(jetAudioSource.pitch + 0.025f, 1f);
            yield return wait;
        }
    }

    private IEnumerator JetFadeOut()
    {
        WaitForSeconds wait = new WaitForSeconds(fadeControlRate);

        while (jetAudioSource.volume > 0f)
        {
            jetAudioSource.volume = Mathf.Max(jetAudioSource.volume - 0.05f, 0f);
            jetAudioSource.pitch = Mathf.Max(jetAudioSource.pitch - 0.025f, 0.5f);
            yield return wait;
        }

        jetAudioSource.volume = 0f;
        jetAudioSource.pitch = 0.5f;

        jetAudioSource.Stop();
    }
}

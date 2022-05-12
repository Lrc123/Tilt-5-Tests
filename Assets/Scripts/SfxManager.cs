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
        if (!isJetPlaying)
        {
            audioSource.PlayOneShot(jetOnSound);
            StopAllCoroutines();
            StartCoroutine(DelayJetLoop());
            isJetPlaying = true;
        }
    }

    public void StopJetSound()
    {
        if (isJetPlaying)
        {
            audioSource.PlayOneShot(jetOffSound);
            jetAudioSource.Stop();
            StopAllCoroutines();
            isJetPlaying = false;
        }
    }

    private IEnumerator DelayJetLoop()
    {
        yield return new WaitForSeconds(0.1f);
        jetAudioSource.Play();
    }
}

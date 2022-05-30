using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    public AudioClip clearMusic;
    public AudioClip monsterMusic;

    public float jetFadeTime = 0.2f;
    public float fadeControlRate = 0.01f;
    public float startPitch = 0.5f;
    public float targetPitch = 1f;
    public float targetVolume = 1f;

    private AudioSource audioSource;
    public AudioSource jetAudioSource;
    public AudioSource leavesAudioSource;
    public AudioSource musicAudioSource;
    public AudioLowPassFilter jetAudioFilter;

    public AudioMixer audioMixer;

    private bool isJetPlaying;

    private int numLeaves = 50;
    private LeavesFade leavesFade;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        leavesFade = GetComponent<LeavesFade>();
    }

    private void FixedUpdate()
    {
        float newVal = Mathf.Sin(1f * Time.timeSinceLevelLoad % (2 * Mathf.PI)) * 0.5f + 0.5f;
        newVal = 1050f * newVal + 250f;
        audioMixer.SetFloat("FilterFreq", newVal);
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

    public void UpdateLeaves(int add)
    {
        leavesFade.UpdateLeaves(add);
    }

    public void PlayMusic()
    {
        musicAudioSource.Play();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void PlayClear()
    {
        musicAudioSource.PlayOneShot(clearMusic);
    }

    public void PlayMonster()
    {
        musicAudioSource.PlayOneShot(monsterMusic);
    }

    public void PlayJetSound()
    {
        if (!isJetPlaying)
        {
            //audioSource.PlayOneShot(jetOnSound);
            StopAllCoroutines();
            StartCoroutine(JetFadeIn());
            isJetPlaying = true;
        }
    }

    public void StopJetSound()
    {
        if (isJetPlaying)
        {
            //audioSource.PlayOneShot(jetOffSound);
            StopAllCoroutines();
            StartCoroutine(JetFadeOut());
            isJetPlaying = false;
        }
    }

    public void FadeMusic()
    {
        musicAudioSource.GetComponent<MusicFade>().FadeMusic();
    }

    public void StartTurbo()
    {
        GetComponent<TurboFade>().StartTurbo();
    }

    public void StopTurbo()
    {
        GetComponent<TurboFade>().StopTurbo();
    }

    private IEnumerator JetFadeIn()
    {
        if (!jetAudioSource.isPlaying)
        {
            jetAudioSource.volume = 0f;
            jetAudioSource.pitch = startPitch;
            jetAudioSource.Play();
        }

        WaitForSeconds wait = new WaitForSeconds(fadeControlRate);
        float increment = fadeControlRate / jetFadeTime;

        while (jetAudioSource.volume < targetVolume)
        {
            jetAudioSource.volume = Mathf.Min(jetAudioSource.volume + increment, targetVolume);
            jetAudioSource.pitch = Mathf.Min(jetAudioSource.pitch + increment, targetPitch);
            yield return wait;
        }
    }

    private IEnumerator JetFadeOut()
    {
        WaitForSeconds wait = new WaitForSeconds(fadeControlRate);
        float increment = fadeControlRate / jetFadeTime;

        while (jetAudioSource.volume > 0f)
        {
            jetAudioSource.volume = Mathf.Max(jetAudioSource.volume - increment, 0f);
            jetAudioSource.pitch = Mathf.Max(jetAudioSource.pitch - increment, startPitch);
            yield return wait;
        }

        jetAudioSource.volume = 0f;
        jetAudioSource.pitch = startPitch;

        jetAudioSource.Stop();
    }
}

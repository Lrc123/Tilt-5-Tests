using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTumble : MonoBehaviour
{
    public float minSpeed = 3f;
    public float maxSpeed = 8f;
    public float minRotSpeed = 0.1f;
    public float maxRotSpeed = 1f;
    public float minVol = 0.3f;
    public float maxVol = 1f;
    public float minPitch = 0.75f;
    public float maxPitch = 1.3f;
    public AudioClip[] clips;

    private AudioSource audioSource;
    private Rigidbody rb;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float speed = rb.velocity.magnitude;
        float rotSpeed = rb.angularVelocity.magnitude;
        if (rotSpeed > minRotSpeed)
        {
            //print(rotSpeed);
            //print(speed);
            AudioClip clip = clips[Random.Range(0, clips.Length)];
            audioSource.volume = Mathf.Lerp(minVol, maxVol, rotSpeed / maxRotSpeed);
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.PlayOneShot(clip);
            //print("played a sound");
        }
        //else if (speed > minSpeed)
        //{
        //    AudioClip clip = clips[Random.Range(0, clips.Length)];
        //    audioSource.volume = Mathf.Lerp(minVol, maxVol, speed / maxSpeed);
        //    audioSource.pitch = Random.Range(minPitch, maxPitch);
        //    audioSource.PlayOneShot(clip);
        //    //print("played a sound");
        //}
    }
}

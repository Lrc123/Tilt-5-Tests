using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBoard : MonoBehaviour
{
    private ScoreManager scoreManager;
    private SfxManager sfxManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        sfxManager = FindObjectOfType<SfxManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        scoreManager.score++;
        sfxManager.PlayBumperSound();
    }
}

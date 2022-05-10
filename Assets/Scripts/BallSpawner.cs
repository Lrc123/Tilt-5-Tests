using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject standardBall;

    Transform[] spawnTransforms;

    private void Start()
    {
        int numChildren = transform.childCount;
        spawnTransforms = new Transform[numChildren];
        for (int i = 0; i < numChildren; ++i)
        {
            spawnTransforms[i] = transform.GetChild(i);
        }
            
    }

    public void SpawnBall()
    {
        int i = Random.Range(0, spawnTransforms.Length);
        Instantiate(standardBall, spawnTransforms[i].position, Quaternion.identity, transform);
    }
}

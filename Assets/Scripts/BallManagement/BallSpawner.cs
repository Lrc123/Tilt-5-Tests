using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject standardBall;

    public float spawnForce = 3f;

    //Transform[] spawnTransforms;

    private void Start()
    {
        // Set up the spawnTransforms array with child "spawn position" transforms
        //int numChildren = transform.childCount;
        //spawnTransforms = new Transform[numChildren];
        //for (int i = 0; i < numChildren; ++i)
        //{
        //    spawnTransforms[i] = transform.GetChild(i);
        //}
    }

    public void SpawnBall()
    {
        //if (spawnTransforms == null)
        //{
        //    int numChildren = transform.childCount;
        //    spawnTransforms = new Transform[numChildren];
        //    for (int i = 0; i < numChildren; ++i)
        //    {
        //        spawnTransforms[i] = transform.GetChild(i);
        //    }
        //}

        //int j = Random.Range(0, spawnTransforms.Length);
        GameObject newBall = Instantiate(standardBall, transform.position, Quaternion.identity, transform);
        newBall.GetComponent<Rigidbody>().AddForce(Vector3.back * spawnForce, ForceMode.Impulse);
    }
}

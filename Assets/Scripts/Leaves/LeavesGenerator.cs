using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesGenerator : MonoBehaviour
{
    public GameObject leaf;

    public int amount;

    public int rateOverTime;

    public int intervalTime;

    public float startTime;

    void Start()
    {
        startTime = 0;

        GenerateAlt();
    }

    void Generate()
    {
        if (Time.time - startTime > intervalTime)
        {
            if (transform.childCount < amount)
            {
                for (int i = 0; i < rateOverTime; i++)
                {
                    Instantiate(leaf, transform.position + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3)), Quaternion.identity, transform);
                }
                startTime = Time.time;
            }
        }
    }

    void GenerateAlt()
    {
        if (transform.childCount < amount)
        {
            for (int i = 0; i < rateOverTime; i++)
            {
                Instantiate(leaf, transform.position + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3)), Quaternion.identity, transform);
            }
            startTime = Time.time;
        }
    }

    void Update()
    {
        //Generate();
    }
}

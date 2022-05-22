using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject platform;

    public List<Transform> targets;

    public int targetIndex = 0;

    public float startTime = 0;

    public float stayDuration = 5f;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, targets[targetIndex].position, 0.05f);
        if ((platform.transform.position - targets[targetIndex].position).magnitude < 0.1f && (Time.time - startTime) > stayDuration)
        {
            targetIndex++;
            targetIndex %= targets.Count;
            startTime = Time.time;
        }
    }


}

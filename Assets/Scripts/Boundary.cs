using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float timeToGo = 2f;
    public float escapeSpeed = 500f;
    public float timeToKill = 4f;
    public AnimationCurve curve;
    private float timeFactor;
    private float lastSpeed;
    private bool isOut;
    private Rigidbody rb;
    private GameObject obj;
    private SfxManager sfxManager;
    private ObjectCount objectCount;

    private void Start()
    {
        objectCount = FindObjectOfType<ObjectCount>();
        sfxManager = FindObjectOfType<SfxManager>();
        timeFactor = 1 / timeToGo;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Leaf" || coll.tag == "WindAffectable")
        {
            coll.GetComponent<KillOffscreen>().isMarked = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Leaf" || coll.tag == "WindAffectable")
        {
            coll.GetComponent<KillOffscreen>().isMarked = false;
        }
    }
}

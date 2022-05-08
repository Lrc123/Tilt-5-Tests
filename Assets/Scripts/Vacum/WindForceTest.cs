using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForceTest : MonoBehaviour
{
    public GameObject TestEmitter;

    public float force = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "WindAffectable")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Impulse);
        }

    }

}

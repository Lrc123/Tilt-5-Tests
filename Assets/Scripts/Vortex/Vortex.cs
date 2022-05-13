using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    [SerializeField]
    private float force = 20f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 dir = transform.position - other.transform.position;
        other.transform.GetComponent<Rigidbody>().AddForce( force * dir, ForceMode.Acceleration);
    }
}

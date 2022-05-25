using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class LeafBounce : MonoBehaviour
{
    public float updraftAmount = 0.1f;

    bool isFallen;

    [HideInInspector]
    public bool isBlown;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isFallen && transform.position.y <= 1f)
        {
            isFallen = true;
            GetComponent<Collider>().isTrigger = false;
        }
    }

    private void FixedUpdate()
    {
        if (isBlown)
        {
            Vector3 dir = Vector3.up;
            dir = Quaternion.AngleAxis(Random.Range(-20f, 20f), Vector3.right) * dir;
            dir = Quaternion.AngleAxis(Random.Range(-20f, 20f), Vector3.forward) * dir;

            //rb.AddForce(updraftAmount * dir);

            //Vector3 towardCam = (TiltFive.Glasses.position - transform.position).normalized * updraftAmount;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isBlown = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class LeafBounce : MonoBehaviour
{
    float updraftAmount = 0.7f;
    float twistAmount = 5f;

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
            dir = Quaternion.AngleAxis(Random.Range(0f, -60f), Vector3.right) * dir;
            dir = Quaternion.AngleAxis(Random.Range(-60f, 60f), Vector3.up) * dir;

            rb.AddForce(updraftAmount * dir);

            Vector3 tor = new Vector3(Random.value, Random.value, Random.value);
            tor *= twistAmount;
            rb.AddTorque(tor, ForceMode.Impulse);

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

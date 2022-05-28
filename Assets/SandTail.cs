using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandTail : MonoBehaviour
{
    public bool isGround = false;

    public bool isMoving = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>().isPlaying)
            {
                transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>().Play();
            }
        }
        else
        {
            if (transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>().isPlaying)
            {
                transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>().Stop();
            }

        }
        if (isGround)
        {
            transform.GetChild(0).GetChild(0).GetComponent<TrailRenderer>().emitting = true;
        }
        else
        {
            transform.GetChild(0).GetChild(0).GetComponent<TrailRenderer>().emitting = false;
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            transform.GetChild(0).transform.position = collision.GetContact(0).point;
            isGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            transform.GetChild(0).transform.position = collision.GetContact(0).point;
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            isGround = false;
        }
    }
}

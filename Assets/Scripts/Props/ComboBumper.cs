using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ComboBumper : MonoBehaviour
{
    public Transform[] next;

    public float force = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            int randomNext = Random.Range(0, next.Length);
            Vector3 nextPos = next[randomNext].position;
            Vector3 direction = nextPos - collision.transform.position;

            Rigidbody ballRb = collision.collider.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            ballRb.AddForce(direction.normalized * force, ForceMode.Impulse);
        }
    }
}

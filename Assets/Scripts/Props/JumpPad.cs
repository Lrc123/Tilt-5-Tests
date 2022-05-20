using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class JumpPad : MonoBehaviour
{
    public float bounceForce = 10f;
    public Transform target;
    public float angle = 0f;
    public bool useTarget = false;

    private bool isLaunching = false;
    private float launchTime = 0.2f;
    private float resetTime = 0.2f;
    private float forceAmount = 12f;

    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;
    private BoxCollider coll;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "WindAffectable" && isLaunching)
        {
            Vector3 direction = Quaternion.AngleAxis(angle, transform.right) * transform.forward;
            if (useTarget && (target != null))
            {
                direction = (target.position - collision.transform.position).normalized;
            }

            Rigidbody ballRb = collision.collider.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;

            ballRb.AddForce(direction * bounceForce, ForceMode.Impulse);
        }
    }

    void Update()
    {
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.One))
        {
            TryLaunch();
        }

        // For testing without Tilt5 wand
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space)) 
        {
            TryLaunch();
        }
    }

    private void TryLaunch()
    {
        if (!isLaunching)
        {
            isLaunching = true;
            StartCoroutine(Launch());
        }
    }

    private IEnumerator Launch()
    {
        rb.isKinematic = false;
        rb.angularVelocity = transform.right * forceAmount;
        Debug.Log("transform right vector: " + transform.right);

        yield return new WaitForSeconds(launchTime);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        float t = 0f;
        float amount = 70f / resetTime;
        while (t < resetTime)
        {
            transform.Rotate(transform.right * Time.deltaTime * amount);
            yield return null;

            t += Time.deltaTime;
        }

        transform.position = startPos;
        transform.rotation = startRot;
        isLaunching = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class JumpPad : MonoBehaviour
{
    public float launchTime = 0.2f;
    public float resetTime = 0.3f;
    public float forceAmount = 2f;
    public float bounceForce = 10f;

    public float angle;

    private bool isLaunching = false;

    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;
    private Vector3 forcePos;

    // Start is called before the first frame update
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
            Rigidbody ballRb = collision.collider.GetComponent<Rigidbody>();
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            ballRb.AddForce(Vector3.forward * bounceForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
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
        rb.angularVelocity = Vector3.right * forceAmount;

        yield return new WaitForSeconds(launchTime);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        float t = 0f;
        float amount = 70f / resetTime;
        while (t < resetTime)
        {
            transform.Rotate(-transform.right * Time.deltaTime * amount);
            yield return null;

            t += Time.deltaTime;
        }

        transform.position = startPos;
        transform.rotation = startRot;
        isLaunching = false;
    }
}

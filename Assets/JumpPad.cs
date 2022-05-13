using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class JumpPad : MonoBehaviour
{
    public float launchTime = 0.2f;
    public float resetTime = 0.3f;
    public float forceAmount = 2f;

    bool isLaunching = false;

    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.One))
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
        //float t = 0f;
        //float amount = 2f / launchTime;
        //while (t < launchTime)
        //{
        //    transform.Translate(transform.up * Time.deltaTime * amount);
        //    yield return null;
        //    t += Time.deltaTime;
        //}

        rb.AddForce(transform.up * forceAmount, ForceMode.Impulse);

        yield return new WaitForSeconds(launchTime);
        rb.velocity = Vector3.zero;
        transform.rotation = startRot;

        float t = 0f;
        float amount = 2f / resetTime;
        while (t < resetTime)
        {
            transform.Translate(-transform.up * Time.deltaTime * amount);
            yield return null;

            t += Time.deltaTime;
        }

        transform.position = startPos;
        isLaunching = false;
    }
}

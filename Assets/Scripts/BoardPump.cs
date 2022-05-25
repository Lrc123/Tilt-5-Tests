using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPump : MonoBehaviour
{
    public float freq;
    public float depth;
    public float dampTime;
    public AnimationCurve dampCurve;
    private float timeFactor;

    private Vector3 startPos;
    private Quaternion startRot;
    bool isPumping = false;

    private float period;

    private void Start()
    {
        startPos = transform.position;
        startRot = Quaternion.identity;
        period = 1f / freq;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && !isPumping)
        //{
        //    PumpIt();
        //}
    }

    public void PumpIt()
    {
        //StartCoroutine(Oscillate());
    }

    private IEnumerator Oscillate()
    {
        isPumping = true;
        float dampDepth = depth;

        float t = 0;
        while (t < dampTime)
        {
            float y = Mathf.Sin(t * 2 * Mathf.PI);
            // TODO: Actually dampen the depth by reading the curve
            transform.position = new Vector3 (startPos.x, y * depth, startPos.z);
            t += Time.deltaTime;
            yield return null;
        }
        isPumping = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float timeToGo = 2f;
    public float escapeSpeed = 500f;
    public float timeToKill = 4f;
    public AnimationCurve curve;
    private float timeFactor;
    private float lastSpeed;
    private bool isOut;
    private Rigidbody rb;
    private GameObject obj;

    private void Start()
    {
        timeFactor = 1 / timeToGo;
    }

    private void Update()
    {
        // DEPRECATED - Leaves blow away fast enough to not need this
        //if (isOut)
        //{
        //    if (lastSpeed > rb.velocity.magnitude && lastSpeed < escapeSpeed)
        //    {
        //        Debug.Log("slow");
        //        //StopAllCoroutines();
        //        //StartCoroutine(BlownAway());
        //        isOut = false;
        //    }
        //    lastSpeed = rb.velocity.magnitude;
        //}
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Leaf")
        {
            //Debug.Log("out");
            coll.GetComponent<MeshRenderer>().enabled = false;
            Destroy(coll.gameObject, timeToKill);

            //isOut = true;
            //rb = coll.attachedRigidbody;
            //lastSpeed = rb.velocity.magnitude;
        }
    }

    IEnumerator Kill(GameObject obj)
    {
        yield return new WaitForSeconds(timeToKill);
        if (obj)
        {
            Destroy(obj);
            //obj.SetActive(false);
            //obj = null;
            Debug.Log("Killed");
        }
        else
        {
            Debug.Log("Object is null");
        }
    }

    //IEnumerator BlownAway()
    //{
    //    Vector3 dir = rb.velocity.normalized;
    //    float speed = rb.velocity.magnitude;
    //    float startSpeed = speed;
    //    Debug.Log("Start speed: " + startSpeed + ", escape speed: " + escapeSpeed);

    //    float t = 0;
    //    while (t < timeToGo)
    //    {
    //        float y = curve.Evaluate(t * timeFactor);
    //        y *= escapeSpeed;
    //        y += startSpeed;
    //        rb.velocity = y * dir;
    //        Debug.Log(y);
    //        t += Time.deltaTime;
    //        yield return null;
    //    }

    //    StartCoroutine(Kill());
    //}
}

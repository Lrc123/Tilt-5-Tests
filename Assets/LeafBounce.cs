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
    private SfxManager sfxManager;

    bool isStuck = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sfxManager = FindObjectOfType<SfxManager>();
    }

    private void Update()
    {

        //if (!isFallen && transform.position.y <= 1f)
        //{
        //    isFallen = true;
        //    GetComponent<Collider>().isTrigger = false;
        //}
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
        string tag = collision.gameObject.tag;
        if (tag == "Ground" || tag == "WindAffectable" || tag == "Obstacle" || tag == "BadObject")
        {
            isBlown = false;
            sfxManager.UpdateLeaves(-1);
        }

        if (!isStuck && tag.Equals("BadObject"))
        {
            isStuck = true;
            StartCoroutine(Stuck());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("BadObject"))
        {
            isStuck = false;
            StopAllCoroutines();
        }
    }

    IEnumerator Stuck()
    {
        float timeStuck = 0f;
        while (timeStuck < 5f)
        {
            yield return null;
            timeStuck += Time.deltaTime;
        }
        //Debug.Log("Object stuck for 5 seconds");
        Destroy(this.gameObject, 1f);
    }

    private void OnDestroy()
    {
        if (isBlown)
        {
            sfxManager.UpdateLeaves(-1);
        }
    }
}

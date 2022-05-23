using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    [SerializeField]
    private float force = 20f;

    void Start()
    {
        
    }

    void Update()
    {
        /*
        var v3Current = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles + new Vector3(0, 0, 10), Time.deltaTime* 0.00001f);
        transform.eulerAngles = v3Current;
        transform.Rotate(v3Current);
        */
        //transform.Rotate(0, 0, 50 * Time.deltaTime);
        //transform.Rotate(Vector3.forward * 50 * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Leaf") || other.tag.Equals("Ball"))
        {
            var tmp = other.GetComponent<Rigidbody>();
            if (tmp != null)
            {
                tmp.velocity = Vector3.zero;
                tmp.drag = 10;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Leaf") || other.tag.Equals("Ball"))
        {
            Vector3 dir = transform.position - other.transform.position;
            other.transform.GetComponent<Rigidbody>().AddForce(force * dir, ForceMode.Acceleration);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerBumper : MonoBehaviour
{
    [SerializeField]
    private float force = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, -transform.forward, Color.green);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "WindAffectable") {
            collision.collider.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);    
        }
    }
}

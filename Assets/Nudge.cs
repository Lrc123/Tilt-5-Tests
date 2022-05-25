using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nudge : MonoBehaviour
{
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(force * Vector3.left);
        } 
    }

}

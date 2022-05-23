using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLimitation : MonoBehaviour
{
    // Start is called before the first frame update
    public float heightLimitation;
    void Start()
    {
        heightLimitation = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y >= heightLimitation)
        {
            this.transform.position = new Vector3(this.transform.position.x, heightLimitation, this.transform.position.z);
        }
    }
}

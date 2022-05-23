using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCross : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, new Vector3(0, 90, 0), 0.01f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, this.transform.eulerAngles + new Vector3(0, 90, 0), 0.5f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughManager : MonoBehaviour
{
    public Camera cam;

    public GameObject mask; 

    void Start()
    {
        
    }

    void Update()
    {
        HandleMask();
    }

    void HandleMask()
    {
        mask.transform.position = cam.transform.position + cam.transform.forward * 5;
    }

}

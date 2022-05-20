using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = transform.GetComponent<Renderer>().material.color;
        newColor.a = 0.1f;
        transform.GetComponent<Renderer>().material.color = newColor;
    }
}

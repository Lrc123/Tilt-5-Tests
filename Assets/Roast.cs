using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class Roast : MonoBehaviour
{
    public Transform marshmallow;
    public Color freshMallow;
    public Color burntMallow;
    public float roastDistance = 5f;

    private Material mallowMat;

    private float roastAmount;
    private float roastMult = 0.0005f;

    // Start is called before the first frame update
    void Start()
    {
        mallowMat = marshmallow.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, marshmallow.position);

        if (distance < roastDistance)
        {
            roastAmount += (roastDistance - distance) * roastMult;
        }

        Color newColor = Color.Lerp(freshMallow, burntMallow, roastAmount);
        mallowMat.color = newColor;
    }
}

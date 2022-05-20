using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskForBall : MonoBehaviour
{
    public GameObject mask;

    private GameObject myMask;

    void Start()
    {
        myMask = Instantiate(mask, transform);
    }

    void Update()
    {
        
    }
}

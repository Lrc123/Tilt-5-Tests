using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoatedGate : MonoBehaviour
{
    public List<float> rotationList;

    public int index = 0;

    public GameObject targetObj;


    void Start()
    {
    }

    void Update()
    {
        Debug.Log((targetObj.transform.eulerAngles - new Vector3(0, rotationList[index], 0)).magnitude);
        float deltaAngle = (targetObj.transform.eulerAngles - new Vector3(0, rotationList[index], 0)).magnitude;
        if (deltaAngle > 10f && deltaAngle < 350f)
        {
            targetObj.transform.eulerAngles = Vector3.Lerp(targetObj.transform.eulerAngles, new Vector3(0, rotationList[index], 0), 0.01f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            index = 1;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Transform camPos;

    public Transform board;
    private bool isDefault = true;

    private void Start()
    {
        //oppositeRot = defaultRot;
        //oppositeRot.Rotate(Vector3.up, 180f);
    }

    private void Update()
    {
        if (isDefault && camPos.localPosition.z > 0f)
        {
            board.Rotate(Vector3.up, 180f);
            isDefault = false;
        }
        else if (!isDefault && camPos.localPosition.z < 0f)
        {
            board.Rotate(Vector3.up, 180f);
            isDefault = true;
        }

        //if (camPos.localPosition.z > 0f)
        //{
        //    everything.parent = oppositeRot;
        //}
        //else if (camPos.localPosition.z < 0f)
        //{
        //    everything.parent = defaultRot;
        //}
    }
}

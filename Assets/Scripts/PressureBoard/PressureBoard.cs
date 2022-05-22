using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureBoard : MonoBehaviour
{

    public List<GameObject> currentCollisions;
    public GameObject gate;

    public Transform start;

    public Transform end;

    private Transform target;

    public int num = 0;

    void Start()
    {
        target = transform;
        currentCollisions = new List<GameObject>();

    }

    void OpenGate()
    {
        target = end;
    }

    void CloseGate()
    {
        target = start;
    }

    void Update()
    {
        if ((num = CountBalls()) >= 3)
        {
            OpenGate();
        }
        else
        {
            CloseGate();
        }
        gate.transform.position = Vector3.MoveTowards(gate.transform.position, target.position, 0.1f);
    }

    private int CountBalls()
    {
        int count = 0;
        for (int i = 0; i < currentCollisions.Count; i++)
        {
            if (currentCollisions[i].tag.Equals("WindAffectable"))
            {
                count++;
            }
        }
        return count;
    }


    void OnCollisionEnter(Collision collision)
    {
        currentCollisions.Add(collision.gameObject);
    }

    void OnCollisionExit(Collision collision)
    {
        currentCollisions.Remove(collision.gameObject);
    }
}

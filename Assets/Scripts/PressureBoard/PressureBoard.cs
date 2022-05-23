using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureBoard : MonoBehaviour
{

    public List<GameObject> currentCollisions;

    public Transform start;

    public Transform end;

    private Transform target;

    private bool isShow = false;

    public Animator monsterShow;

    public int num = 0;

    public float startTime;

    void Start()
    {
        start = transform;
        target = transform;
        startTime = Time.time;
        currentCollisions = new List<GameObject>();
    }

    void Update()
    {
        target = end;
        //currentCollisions[i].transform.position = Vector3.MoveTowards(currentCollisions[i].transform.position, target.position, 0.1f);
        if ((Time.time - startTime) > 2)
        {
            if (currentCollisions.Count > 0)
            {
                if (!isShow)
                {
                    monsterShow.SetTrigger("MonsterShow");
                    isShow = true;
                }
                currentCollisions[0].GetComponent<BallLimitation>().heightLimitation = 20f;
                currentCollisions[0].transform.position = target.position;
                startTime = Time.time;
            }
        }
    }

    private int CountBalls()
    {
        int count = 0;
        for (int i = 0; i < currentCollisions.Count; i++)
        {
            if (currentCollisions[i].tag.Equals("Ball"))
            {
                count++;
            }
        }
        return count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball"))
        {
            currentCollisions.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentCollisions.Remove(other.gameObject);
    }

}

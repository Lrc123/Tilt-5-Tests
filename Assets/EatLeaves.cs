using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatLeaves : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Leaf"))
        {
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("Ball"))
        {
            other.transform.position = startPoint.position;
        }
    }


}

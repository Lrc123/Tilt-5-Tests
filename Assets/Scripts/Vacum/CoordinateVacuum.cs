using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateVacuum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FixeStartCoordinate();
        Coordinate(Vector3.down);
        //Coordinate(transform.TransformDirection(Vector3.down));
    }

    private void FixeStartCoordinate()
    {
        if (transform.position == Vector3.zero)
        {
            transform.position = new Vector3(0, 1, 0);
        }
    }

    private void Coordinate(Vector3 dir)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity))
        {
            if (hit.distance < 1f)
            {
                transform.position = new Vector3(transform.position.x, hit.point.y + 1f, transform.position.y);
            }
            Debug.DrawRay(transform.position, (dir) * 1000, Color.red);
            Debug.Log("Did Hit ");
        }
        else
        {
            Debug.DrawRay(transform.position, (dir) * 1000, Color.green);
            Debug.Log("Did not hit");
        }
        
    }
}

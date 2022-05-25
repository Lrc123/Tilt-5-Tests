using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;
public class MoveBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 stick = TiltFive.Input.GetStickTilt();    

        Debug.Log(stick.x + ", " + stick.y);
        Vector3 move = new Vector3(stick.x, 0f, stick.y);

       transform.position += move;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class MoveBall : MonoBehaviour
{
    public Transform wandAim;
    public Transform gameBoard;
    public float forceMult = 0.01f;

    private Rigidbody rb;
    private Vector3 moveForce;
    private Vector3 lastWandSpherePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToWandAim = Vector3.Distance(transform.position, wandAim.position);


        Vector3 between = transform.position - wandAim.position;

        float forceDir = 0;
        if (TiltFive.Input.GetButton(TiltFive.Input.WandButton.X))
        {
            forceDir = 1;
        }
        else if (TiltFive.Input.GetButton(TiltFive.Input.WandButton.B))
        {
            forceDir = -1;
        }

        moveForce = between * forceDir * between.magnitude * forceMult;
        


        // Move game board to track ball
        gameBoard.position = transform.position;

        // Move sphere based on wand movement
        //Vector3 newWandSpherePos = wandAim.position;
        //float wandMoveDelta = Vector3.Distance(newWandSpherePos, lastWandSpherePos);
        //Quaternion glassesRot = TiltFive.Glasses.rotation;
        //Debug.Log(wandMoveDelta);
        //if (wandMoveDelta > 0.5f)
        //{
        //    // Move in the direction the wand is facing, with force proportional to wand move speed
        //    moveForce = (wandMoveDelta - 0.5f) * 10f * (glassesRot * Vector3.forward);
        //}
        //else
        //{
        //    moveForce = Vector3.zero;
        //}
        //lastWandSpherePos = newWandSpherePos;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveForce);

    }
}

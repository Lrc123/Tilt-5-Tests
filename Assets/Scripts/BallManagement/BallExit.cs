using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExit : MonoBehaviour
{
    BallManager ballManager;

    private void Start()
    {
        ballManager = GetComponentInParent<BallManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ballManager == null)
        {
            ballManager = GetComponentInParent<BallManager>();
        }
        if (other.tag == "WindAffectable")
        {
            // Decrement ball count in BallManager
            ballManager.DecrementBallCount();
            // Destroy ball
            Destroy(other.gameObject);
        }
    }
}

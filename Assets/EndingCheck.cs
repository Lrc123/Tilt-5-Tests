using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCheck : MonoBehaviour
{
    public int ballCount = 0;
    public Animator DonutMove;
    private bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (ballCount == 3 && !isPlay)
        {
            DonutMove.SetTrigger("DonutMove");
            isPlay = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ball"))
        {
            ballCount++;
            Destroy(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPop : MonoBehaviour
{
    public Animator MPop;
    private bool isEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
            return;
        //capDropped();
    }

    private void capDropped()
    {
        if(transform.position.y < 0.5f)
        {
            MPop.SetTrigger("Pop");
            Destroy(MPop.gameObject, 2.2f);
            isEnd = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.tag.Equals("Ground") || collision.collider.tag.Equals("Boundary")) && !isEnd)
        {
            //MPop.gameObject.transform.parent = FindObjectOfType<LeafGenerator>().transform;
            FindObjectOfType<GoToEnd>().started = true;
            FindObjectOfType<SfxManager>().PlayMonster();
            //MPop.SetTrigger("Pop");
            Destroy(MPop.gameObject, 2.2f);
            isEnd = true;
        }
    }
}

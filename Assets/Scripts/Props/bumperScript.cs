using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperScript : MonoBehaviour
{
    private Vector3 originalPos;
    public bool isDisappered = false;
    
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WindAffectable")
        {
            //gameObject.SetActive (false);

            Disappear(0.1f);
        }
    }

    void Disappear(float num)
    {
        isDisappered = true;
        transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
    }

    public void Reappear()
    {
        GoBack(0.1f);
    }


    void GoBack(float interval)
    {
        isDisappered = false;
        transform.position = originalPos;
    }
}

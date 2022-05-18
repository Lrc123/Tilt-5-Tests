using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperScript : MonoBehaviour
{
    private Vector3 originalPos;
    // Start is called before the first frame update
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
            
            StartCoroutine(Disappear(0.5f));
        }
    }

    IEnumerator Disappear(float num)
    {
        yield return new WaitForSeconds(num);
        transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
        StartCoroutine(GoBack(3));
    }


    IEnumerator GoBack(float interval)
    {
        yield return new WaitForSeconds(interval);
        transform.position = originalPos;
    }
}

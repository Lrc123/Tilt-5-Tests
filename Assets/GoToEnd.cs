using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToEnd : MonoBehaviour
{
    public Transform endPosition;

    public Transform lookAtPosition;

    public bool started = false;

    private float timer;

    private float startScale;

    void Start()
    {
        timer = 0;
        startScale = transform.localScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            timer += Time.deltaTime;
       
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, 0.15f);
            transform.LookAt(lookAtPosition);
            float newScale = Mathf.Lerp(startScale, 2.5f * startScale, timer / 1.5f);
            transform.localScale = newScale * Vector3.one;
            Debug.Log(newScale);
            
        }
    }
}

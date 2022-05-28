using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOffscreen : MonoBehaviour
{
    [HideInInspector] public bool isMarked = false;
    private bool isDead = false;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (isMarked && !renderer.isVisible && !isDead)
        {
            FindObjectOfType<ObjectCount>().UpdateCount(1);
            isDead = true;
            Destroy(this.gameObject);
        }

        if (transform.position.y < -10f && !isDead)
        {
            FindObjectOfType<ObjectCount>().UpdateCount(1);
            isDead = true;
            Destroy(this.gameObject);
        }
    }
}

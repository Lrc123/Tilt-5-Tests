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
        if (isMarked && renderer.isVisible)
        {
            FindObjectOfType<ObjectCount>().UpdateCount(1);
            Destroy(this.gameObject, 2f);
            isDead = true;
        }
    }
}

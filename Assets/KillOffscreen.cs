using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOffscreen : MonoBehaviour
{
    [HideInInspector] public bool isMarked = false;
    private bool isDead = false;
    private Renderer renderer;
    private bool isStuck;
    private Coroutine stuckCoroutine;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (isMarked && !isDead)
        {
            FindObjectOfType<ObjectCount>().UpdateCount(1);
            isDead = true;
            StartCoroutine(FadeAndDestroy());
        }

        if (transform.position.y < -10f && !isDead)
        {
            FindObjectOfType<ObjectCount>().UpdateCount(1);
            isDead = true;
            Destroy(this.gameObject);
        }
    }

    IEnumerator FadeAndDestroy()
    {
        float t = 0f;
        Rigidbody rb = GetComponent<Rigidbody>();
        //Color startColor = renderer.material.color;
        //Color endColor = startColor;
        //endColor.a = 0f;
        while (t < 2f)
        {
            //Color newAlpha = Color.Lerp(startColor, endColor, t * 0.5f);
            //renderer.material.color = newAlpha;
            Vector3 dir = transform.position - Vector3.zero;
            rb.AddForce(0.5f * dir);
            yield return null;
            t += Time.deltaTime;
        }

        Destroy(this.gameObject);
    }
}

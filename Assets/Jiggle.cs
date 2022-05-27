using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiggle : MonoBehaviour
{
    private Animator animator;

    bool isJiggling = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayJiggle(float speed)
    {
        animator.speed = speed;
        if (!isJiggling)
        {
            print("jiggle");
            animator.SetTrigger("Jiggle");
            isJiggling = true;
        }
    }

    public void UpdateSpeed(float speed)
    {
        if (isJiggling)
        {
            animator.speed = speed;
        }
    }

    private void EndJiggle()
    {
        isJiggling = false;
    }
}

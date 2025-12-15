using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
       
        animator.Play("BackgroundMenu");
        animator.Play("BackgroundMenu3");
        animator.Play("BackgroundMenu2");
    }


}

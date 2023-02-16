using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTalking : MonoBehaviour
{
    public GameObject chicken;
    public Animator animator;

    public void chickenIdle()
    {
        animator.SetBool("ChickenIdle", true);
        animator.SetBool("ChickenGone", false);
    }

    public void chickenGone()
    {
        animator.SetBool("ChickenGone", true);
        animator.SetBool("ChickenIdle", false);
    }


}

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
    }

    public void chickenGone()
    {
        animator.SetBool("ChickenGone", true);
    }


}

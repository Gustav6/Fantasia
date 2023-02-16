using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;
    public DialogueManager begin;
    public Animator animator;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            trigger.startDialogue();
            animator.SetBool("ChickenAppear", true);
            animator.SetBool("ChickenDisapear", false);
        }   
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
                begin.ExitDialogueIfToFarAway();
            animator.SetBool("ChickenDisapear", true);
            animator.SetBool("ChickenAppear", false);
        }
    }
}

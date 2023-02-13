using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;
    public DialogueManager begin;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
            trigger.startDialogue();
        //Startar dialoguen när man går in i NPCs hitbox
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
                begin.ExitDialogueIfToFarAway();
        }
    }
}

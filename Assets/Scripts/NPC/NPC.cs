using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
            trigger.startDialogue();
        //Startar dialoguen n�r man g�r in i NPCs hitbox
    }
}

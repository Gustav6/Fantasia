using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledBoxLimit : MonoBehaviour
{
    PlayerMovement playerScript;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ControllBox"))
        {
            playerScript.isControlling = false;
        }
    }
}

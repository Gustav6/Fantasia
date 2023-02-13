using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckpointSystem : MonoBehaviour
{
    public Transform currentRespawnPoint;
    public GameObject player;

    public PlayerMovement playerScript;

    private void Start()
    {
        currentRespawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void ResetLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.transform.position = currentRespawnPoint.position;

            playerScript.velocity.y = 0f;
        }
    }
}

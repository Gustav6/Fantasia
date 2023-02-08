using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckpointSystem : MonoBehaviour
{
    public Transform currentRespawnPoint;
    public GameObject player;

    private void Start()
    {
        currentRespawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ResetLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.transform.position = currentRespawnPoint.position;
        }
    }
    
}

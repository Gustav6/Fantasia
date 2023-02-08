using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckpointSystem : MonoBehaviour
{
    public Transform currentRespawnPoint;
    public Player player;

    public void ResetLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.transform.position = currentRespawnPoint.position;
        }
    }
    
}

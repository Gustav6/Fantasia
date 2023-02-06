using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class Checkpoints : MonoBehaviour
{
    public GameObject Player;
    private Vector3 respawnPoint;
    void start()
    {
        respawnPoint = Player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        respawnPoint = Player.transform.position;
    }
    public void ResetLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Player.transform.position = respawnPoint;
            Debug.Log("H");
        }
    }
}

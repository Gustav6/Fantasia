using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class Checkpoints : MonoBehaviour
{
    public Transform currentRespawnPoint;

    public Vector3 respawnPoint;   

    public float rayLength = 1000f;
    public GameObject player;

    public LayerMask collisions;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentRespawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, rayLength, collisions);

            respawnPoint = hit.point;
            respawnPoint.y += 0.6f;

            currentRespawnPoint.transform.position = respawnPoint;
        }

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class Checkpoints : MonoBehaviour
{
    public Transform currentRespawnPoint;
    public GameObject player;
    public Player playerVelocity;

    public Vector3 respawnPoint;   
    public LayerMask collisions;

    public float rayLength = 1000f;
    public float minHeightForRespawn = -20f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentRespawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        playerVelocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (player.transform.position.y < minHeightForRespawn)
        {
            player.transform.position = currentRespawnPoint.position;
            playerVelocity.velocity.y = 0f; 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, rayLength, collisions);

            respawnPoint = hit.point;
            respawnPoint.y += 0.53f;

            currentRespawnPoint.transform.position = respawnPoint;
        }
    }
}
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
    public PlayerMovement playerScript;
    public SpriteRenderer checkpointLight;

    public Vector3 respawnPoint;   
    public LayerMask collisions;

    public float rayLength = 1000f;
    public float minHeightForRespawn = -20f;
    public float RespawnHeight;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentRespawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (player.transform.position.y < minHeightForRespawn)
        {
            player.transform.position = currentRespawnPoint.position;
            playerScript.velocity.y = 0f; 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.down, rayLength, collisions);

            respawnPoint = hit.point;
            respawnPoint.y += RespawnHeight / 2;

            currentRespawnPoint.transform.position = respawnPoint;
            checkpointLight.color = Color.green;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToStart : MonoBehaviour
{
    public GameObject player;
    public Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = spawnPoint; 
    }
}

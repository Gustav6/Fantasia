using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject pressurePlate;

    public LayerMask collisions;

    public float rayLength = 0.5f;

    void Start()
    {
        pressurePlate = GameObject.FindGameObjectWithTag("PressurePlate");
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(pressurePlate.transform.position, Vector2.up, rayLength, collisions);

        Debug.DrawRay(pressurePlate.transform.position, Vector2.up, Color.blue);

        if (hit)
        {
            pressurePlate.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        }
        if (!hit)
        {
            pressurePlate.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }

    }
}

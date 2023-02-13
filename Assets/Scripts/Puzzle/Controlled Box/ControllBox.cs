using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(Controller2D))]
public class ControllBox : MonoBehaviour
{
    #region The Logic For The Controlled Box
    [Header("Logic")]

    [Tooltip("What velocity the box has on the x and y axis")]
    public Vector2 velocity;
    #endregion

    #region Controlled Box Horizontal Movement
    [Header("Controlled Box Horizontal Movement")]

    [Tooltip("The x input for the controlled box")]
    public float xBoxInput;
    [Tooltip("The move speed for the controlled box on the x axis")]
    public float controlledBoxSpeed;
    [Tooltip("Acceleration for the controlled box on the x axis")]
    public float velocityXSmothing;
    #endregion

    // A call for the player so i can refrence the player and get the gravity
    public GameObject player;

    // A call for the players script so i can reuse variables
    public PlayerMovement playerScript;
    public InteractDistance interactDistance;

    // A variabel to call the script Controller2D
    Controller2D controller;


    void Start()
    {
        controller = GetComponent<Controller2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactDistance = GameObject.FindGameObjectWithTag("InteractDistance").GetComponent<InteractDistance>();
    }

    void Update()
    {
        if (playerScript.isControlling)
        {
            float targetVelocityX = xBoxInput * controlledBoxSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmothing, (controller.collisions.below) ? playerScript.accelerationTimeGrounded : playerScript.accelerationTimeAirborne);
        }
        else if (!playerScript.isControlling)
        {
            velocity.x = 0f;
        }

        velocity.y = Mathf.Clamp(velocity.y, -20, 20);
        velocity.y += playerScript.gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0f;
        }
    }

    public void XBoxInput(InputAction.CallbackContext context)
    {
        if (playerScript.isControlling)
        {
            xBoxInput = context.ReadValue<Vector2>().x;
        }
    }
    public void YBoxInput(InputAction.CallbackContext context)
    {
        if (playerScript.isControlling)
        {
            if (context.started && controller.collisions.below)
            {
                velocity.y = playerScript.maxJumpVelocity / 1.4f;
            }

            if (context.canceled)
            {
                if (velocity.y > playerScript.minJumpVelocity)
                {
                    velocity.y = playerScript.minJumpVelocity / 1.4f;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

[RequireComponent(typeof(Controller2D))]
public class BoxMovement : MonoBehaviour
{
    #region The Logic For The Box
    [Header("Logic")]

    [Tooltip("How high the gravity it will be on the box")]
    public float gravity;
    [Tooltip("What velocity the box has on the x and y axis")]
    public Vector2 velocity;
    #endregion

    #region Box Movement
    [Header("Box Movement")]

    [Tooltip("How high the box movements speed will be")]
    public float boxMoveSpeed = 5f;
    [Tooltip("How long the box will will move after player doesnt collide with it")]
    public float deAcceleration = 15f;
    #endregion

    // A call for the player so i can refrence the player and get the gravity
    public GameObject player;

    // A variabel to call the script Controller2D
    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        gravity = player.GetComponent<Player>().gravity;

        velocity.y = Mathf.Clamp(velocity.y, -20, 20);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (!player.GetComponent<Controller2D>().collisions.left || !player.GetComponent<Controller2D>().collisions.right)
        {
            if (velocity.x < 0.01f && velocity.x > -0.01f)
            {
                velocity.x = 0f;
            }
            else if (velocity.x > 0)
            {
                velocity.x -= deAcceleration * Time.deltaTime;
            }
            else if (velocity.x < 0)
            {
                velocity.x += deAcceleration * Time.deltaTime;
            }
        }

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0f;
        }
    }

    public void MoveBox()
    {
        if (player.GetComponent<Controller2D>().collisions.right)
        {
            velocity.x = boxMoveSpeed;
        }
        else if (player.GetComponent<Controller2D>().collisions.left)
        {
            velocity.x = -boxMoveSpeed;
        }
    }
}

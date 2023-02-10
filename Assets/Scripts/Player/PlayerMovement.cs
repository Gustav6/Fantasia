using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Players Vertical Movment
    [Header("Veritcal Movment")]

    [Tooltip("Maximum height the player can jump")]
    [SerializeField] float maxJumpHeight = 4f;
    [Tooltip("Minimum height the player can jump")]
    [SerializeField] float minJumpHeight = 2f;
    [Tooltip("How long it takes the player to reach the variabel jumpHeight")]
    [SerializeField] float timeToJumpApex = .4f;
    [Tooltip("The maximum amount of jump speed for the player")]
    public float maxJumpVelocity;
    [Tooltip("The minimum amount of jump speed for the player")]
    public float minJumpVelocity;
    #endregion

    #region Players Horizontal Input & Movment
    [Header("Horizontal Movment")]

    [Tooltip("The acceleration then airborne on the x axis")]
    public float accelerationTimeAirborne = .2f;
    [Tooltip("The acceleration when grounded on the x axis")]
    public float accelerationTimeGrounded = .1f;
    [Tooltip("The top speed on the x axis")]
    [SerializeField] float moveSpeed = 6f;
    [Tooltip("Acceleration for the player on the x axis")]
    public float velocityXSmothing;
    // players input on the x axis
    public float xInput;
    #endregion

    #region The Logic For The Player
    [Header("Logic")]

    [Tooltip("How high the gravity it will be on the player")]
    public float gravity;
    [Tooltip("The players velocity on the x and y axis")]
    public Vector2 velocity;
    #endregion

    #region Refrences For Box
    [Header("Refrences For Box")]

    [Tooltip("The Boxes velocity on the x axis")]
    public float boxVelocity;
    [Tooltip("Refrence to the box game object")]
    public GameObject box;
    #endregion

    #region Player Sprite
    private SpriteRenderer spriteRenderer;
    Animator animator;
    #endregion

    // A variabel to call the script Controller2D
    public Controller2D controller;

    // A bool to check if the player is controlling a box
    public bool isControlling = false;

    void Start()
    {
        controller = GetComponent<Controller2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity)) * minJumpHeight;
    }

    void Update()
    {
        bool flipSprite = (spriteRenderer.flipX ? (velocity.x > 0.01f) : (velocity.x < -0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("Grounded", controller.collisions.below);

        if (!controller.collisions.below)
        {
            //animator.SetFloat("SpeedY", velocity.y);
        }
        else
        {
            //animator.SetFloat("SpeedY", 0);
        }

        //animator.SetFloat("SpeedX", Mathf.Abs(xInput));

        float targetVelocityX = xInput * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y = Mathf.Clamp(velocity.y, -20, 20);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0f;
        }
    }

    public void XInput(InputAction.CallbackContext context)
    {
        if (!isControlling)
        {
            xInput = context.ReadValue<Vector2>().x;
        }
    }

    public void YInput(InputAction.CallbackContext context)
    {
        if (!isControlling)
        {
            if (context.started && controller.collisions.below)
            {
                velocity.y = maxJumpVelocity;
            }

            if (context.canceled)
            {
                if (velocity.y > minJumpVelocity)
                {
                    velocity.y = minJumpVelocity;
                }
            }
        }
    }

    public void Controll(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isControlling = !isControlling;

            print(isControlling);

            xInput = 0f;
        }
    }
}


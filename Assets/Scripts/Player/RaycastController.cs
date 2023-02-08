using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour
{
    #region Raycasts from player
    [Header("Raycasts from player")]

    [Tooltip("The amount of raycasts coming out from players sides")]
    public int horizontalRayCount = 4;
    [Tooltip("The amount of raycasts coming out from players top and bottom")]
    public int verticalRayCount = 4;

    // Skin width means that raycast start a little inside player, so that collisions dont get messed up
    [HideInInspector]
    public const float skinWidth = .015f;
    #endregion

    #region Collisions
    [HideInInspector]
    public float horizonalRaySpacing;
    [HideInInspector]
    public float verticalRaySpacing;
    [HideInInspector]
    public new BoxCollider2D collider;
    #endregion

    // What layer that can be collided with from the player
    public LayerMask collisionMask;

    // The origin from where the raycast are cast from 
    public RaycastOrigins raycastOrigins;

    public GameObject player;

    public virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collider = GetComponent<BoxCollider2D>();
    }

    public virtual void Start()
    {
        CalculateRaySpacing();
    }

    public void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);

        horizonalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

}

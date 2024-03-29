using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPressureplateLight : MonoBehaviour
{
    public Light Light;
    public Collider2D platfromCollider;
    public SpriteRenderer platform;
    //public SpriteRenderer pushBoxText;
    public GameObject visiblePlatform;
    public GameObject invisiblePlatform;
    public GameObject Cube;

    [SerializeField] float castRadius;

    private bool pressurePlateActivation = false;

    [SerializeField] List<GameObject> onPressurePlate = new List<GameObject>();

    private void FixedUpdate()
    {
        if (pressurePlateActivation)
        {
            Light.color = Color.green;
            visiblePlatform.SetActive(false);
            invisiblePlatform.SetActive(true);

            //pushBoxText.color = new Color(1f, 1f, 1f, .0f);
        }
        else if (!pressurePlateActivation)
        {
            Light.color = Color.red;
            visiblePlatform.SetActive(true);
            invisiblePlatform.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collisions)
    {
        Physics2D.CircleCastAll(transform.position, castRadius, Vector2.zero);

        if (collisions.gameObject.CompareTag("Player") || collisions.gameObject.CompareTag("Box"))
        {
            pressurePlateActivation = true;

            onPressurePlate.Add(collisions.gameObject);
            

            if (onPressurePlate.Count != 0)
            {
                pressurePlateActivation = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collisions)
    {
        onPressurePlate.Remove(collisions.gameObject);

        if (onPressurePlate.Count == 0)
        {
            pressurePlateActivation = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, castRadius);
    }
}

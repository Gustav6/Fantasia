using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPressureplateLight : MonoBehaviour
{
    public Light Light;
    public Collider2D platfromCollider;
    public SpriteRenderer platform;
    public SpriteRenderer pushBoxText;
    public GameObject visiblePlatform;
    public GameObject invisiblePlatform;
    public GameObject Cube;

    private bool pressurePlateActivation = false;
    private bool cubeAtPressurePlate = false;

    private void FixedUpdate()
    {
        if (pressurePlateActivation == true)
        {
            Light.color = Color.green;
            Debug.Log("Color Switch");
            visiblePlatform.SetActive(false);
            invisiblePlatform.SetActive(true);
            pushBoxText.color = new Color(1f, 1f, 1f, .0f);
        }
        else if (pressurePlateActivation == false)
        {
            Light.color = Color.red;
            Debug.Log("Color Switch");
            visiblePlatform.SetActive(true);
            invisiblePlatform.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collisions)
    {
        if (collisions.gameObject.tag == "Player" || collisions.gameObject.tag == "Box")
        {
            pressurePlateActivation = true;
            if (collisions.gameObject.tag == "Box")
            {
                cubeAtPressurePlate = true;
            }
            else
            {
                cubeAtPressurePlate = false;
            }


        }

    }
    private void OnTriggerExit2D(Collider2D collisions)
    {
        if (cubeAtPressurePlate == true)
        {
            pressurePlateActivation = true;
        }
        else
        {
            pressurePlateActivation = false;
        }

           
    }
}

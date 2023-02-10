using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPressureplateLight : MonoBehaviour
{
    public Light myLight;
    public Collider2D platfromCollider;
    public SpriteRenderer platform;

    private void OnTriggerEnter2D(Collider2D collisions)
    {
        if (collisions.gameObject.tag == "Player" || collisions.gameObject.tag == "Box")
        {
            myLight.color = Color.green;
            Debug.Log("Color Switch");
            GameObject.FindGameObjectWithTag("InvisblePlatform").GetComponent<CapsuleCollider2D>().enabled = true;
            platform.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collisions)
    {
        if (collisions.gameObject.tag == "Player" || collisions.gameObject.tag == "Box")
        {
            myLight.color = Color.red;
            Debug.Log("Color Switch");
            GameObject.FindGameObjectWithTag("InvisblePlatform").GetComponent<CapsuleCollider2D>().enabled = false;
            platform.color = new Color(1f, 1f, 1f, .5f);
        }
    }
}

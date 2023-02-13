using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDistance : MonoBehaviour
{
    public bool canControllBox;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canControllBox = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canControllBox = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpick : MonoBehaviour
{

    public GameObject lockPickUI;
    public GameObject pick;

    private bool IsAtLock = false;

    void Update()
    {

        if (Input.GetKey(KeyCode.E) && IsAtLock == true)
        {
            lockPickUI.SetActive(true);
            pick.SetActive(true);

            if (Input.GetKey(KeyCode.Mouse1))
            {
                PickMovement();
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsAtLock = true;

            Debug.Log("Interacted");
        }

        Debug.Log("Trigger");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsAtLock = false;
        lockPickUI.SetActive(false);
    }

    public void PickMovement()
    {

    }


}

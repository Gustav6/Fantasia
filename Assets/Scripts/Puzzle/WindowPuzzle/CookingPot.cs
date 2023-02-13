using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPot : MonoBehaviour
{
    private bool IsAtPot = false;

    public GameObject CookingPotUI;

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && IsAtPot == true)
        {
            CookingPotUI.SetActive(true);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsAtPot = true;

            Debug.Log("Interacted with pot");
        }

        Debug.Log("Touched Pot");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsAtPot= false;
        CookingPotUI.SetActive(false);
    }

}

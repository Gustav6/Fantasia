using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public class Hat : MonoBehaviour
{
    public GameObject hat;
    public bool hatInInventory = false;
    public GameObject whaleWithoutHat;
    public GameObject whaleWithHat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hat.SetActive(false);
        hatInInventory = true;
        whaleWithoutHat.SetActive(false); whaleWithHat.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject StartGame;
    void Update()
    {
        if (Input.anyKey)
        {
            MainMenu.SetActive(true);
            StartGame.SetActive(false);
        }
    }
}

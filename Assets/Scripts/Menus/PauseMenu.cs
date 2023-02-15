using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject MenuUI;
    public GameObject SettingsUI;
    public GameObject CodePanel;
    public GameObject DialogueUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) 
            {
                Resume();
                Debug.Log("Resuming");
            }
            else
            {
                Pause();
                Debug.Log("Pausing Game");
                CodePanel.SetActive(false);
                

            }

        }
    }

    public void Resume()
    {
        MenuUI.SetActive(false);
        SettingsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        DialogueUI.SetActive(true);

    }

    void Pause()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        DialogueUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
        MenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}

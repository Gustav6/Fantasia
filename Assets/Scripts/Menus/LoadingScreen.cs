using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour
{
    public GameObject LoadScreen;


    public void LoadScene(int sceneID)
    {
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        LoadScreen.SetActive(true);

        while (!operation.isDone)
        {

            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);


            yield return null;
        }

    }

  

   
}

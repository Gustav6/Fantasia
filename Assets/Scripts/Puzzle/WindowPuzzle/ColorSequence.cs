using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSequence : MonoBehaviour
{
    private bool puzzleCollision = false;

    [SerializeField] private TMPro.TextMeshProUGUI colorText;
    string colorInput = "";
    public string colorPattern;

    public GameObject SequenceUI;
  
    void Update()
    {
        colorText.text = colorInput;
        if (colorInput == colorPattern)
        {
            SequenceUI.SetActive(false);
            Debug.Log("Puzzle completed");
        }

        if (colorInput.Length >= 4)
        {
            colorInput = "";
        }

        if (Input.GetKey(KeyCode.E) && puzzleCollision == true)
        {
              SequenceUI.SetActive(true);
       
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            puzzleCollision = true;
        }

        Debug.Log("Trigger");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        puzzleCollision = false;
        SequenceUI.SetActive(false);
    }

    public void AddDigit(string digit)
    {
        colorInput += digit;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SequencePuzzle : MonoBehaviour
{
    private bool IsAtDoor = false;
    
    [SerializeField] private TMPro.TextMeshProUGUI CodeText;
    string codeTextValue = "";
    public string safeCode;
    public GameObject CodePanel;
    public static bool KeyCodeActive = false;
    public GameObject blockade;
    void Update()
    {
        CodeText.text = codeTextValue;
        if (codeTextValue == safeCode)
        {
            CodePanel.SetActive(false);
            codeTextValue = "";
            Debug.Log("gg ez");
            blockade.SetActive(false);

        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }

        if (Input.GetKey(KeyCode.E) && IsAtDoor == true)
        {
            if (KeyCodeActive)
            {
                CodePanel.SetActive(true);
            }
           else
            {
                CodePanel.SetActive(false);
            }
          
            
        }

        if (Input.GetKey(KeyCode.Backspace) && IsAtDoor == true)
        {
            codeTextValue = "";
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsAtDoor = true;
            KeyCodeActive = true;
        }

        Debug.Log("Trigger");

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
        KeyCodeActive = false;
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
        Debug.Log("Digit:" + digit + "added!");
    }

    
}

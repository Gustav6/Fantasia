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
    void Update()
    {
        CodeText.text = codeTextValue;
        if (codeTextValue == safeCode)
        {
            codeTextValue = "";
            Debug.Log("gg ez");
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IsAtDoor = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

}

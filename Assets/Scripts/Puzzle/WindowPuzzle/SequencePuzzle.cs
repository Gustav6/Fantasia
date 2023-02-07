using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SequencePuzzle : MonoBehaviour
{
    [SerializeField]
    Text codeText;
    string codeTextValue = " ";

    void Update()
    {
        codeText.text = codeTextValue;
        if (codeTextValue == "1234")
        {
            Debug.Log("gg ez");
        }
        if (codeTextValue.Length >= 5)
        {
            codeTextValue = " ";
        }
  
    }
    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}

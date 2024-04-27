using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GetUserInput : MonoBehaviour
{
    TMP_InputField inputField;
    //public GameObject inputField;
    //public int inputOrder;
    public string validatedInputLetter;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.characterLimit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getValidatedInputLetter(string input)
    {
        validatedInputLetter = getValidatedInput(input);
        inputField.text = validatedInputLetter;
    }
    string getValidatedInput(string input)
    {
        // Regular expression pattern to match English letters (case insensitive)
        string pattern = @"[^a-zA-Z]";
        
        // Remove non-English letters from the input using Regex.Replace
        string validatedInput = Regex.Replace(input, pattern, "");

        return validatedInput;
    }
}

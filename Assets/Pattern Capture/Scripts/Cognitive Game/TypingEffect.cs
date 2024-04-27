using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    TextMeshProUGUI dialogueText;
    public GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        dialogueText = this.GetComponent<TextMeshProUGUI>();
        
        string line = "Welcome to your\ncognitive game\nYou are required to find the\nmissing one from\nthe given set of patterns.\n\nLet's start it!";
        StartCoroutine(TypeText(line));
    }
    IEnumerator TypeText(string line)
    {
        float charactersPerSecond = 10;
        string textBuffer = null;
        foreach (char c in line)
        {
            textBuffer += c;
            dialogueText.text = textBuffer;
            yield return new WaitForSeconds(1 / charactersPerSecond);
        }
        startButton.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        

        
    }
}

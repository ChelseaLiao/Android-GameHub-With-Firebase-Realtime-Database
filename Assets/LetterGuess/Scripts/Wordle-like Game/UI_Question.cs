using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Question : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(WordSelection.isRefresh)
        {
            questionDisplay();
            WordSelection.isRefresh = false;
        }
        
    }
    void questionDisplay()
    {
        this.GetComponent<TextMeshProUGUI>().text = WordSelection.randomQuestion;
    }
}

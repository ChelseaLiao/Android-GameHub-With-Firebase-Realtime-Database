using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_InputFeedback : MonoBehaviour
{
    TextMeshProUGUI field;
    float timer;
    bool isCountdown = false;
    public GameObject redFrame;
    public GameObject greenFrame;
    public GameObject yellowFrame;
    public List<GameObject> hightLightObject;
    // Start is called before the first frame update
    void Start()
    {
        field = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCountdown)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                field.text = "";
                if(hightLightObject != null)
                {
                    foreach(var hightLight in hightLightObject)
                        Destroy(hightLight);
                }

                isCountdown = false;
            }
        }
    }
    public void answerFeedback()
    {
        if(!WordValidation.isWrongLength && WordValidation.isEnglish)
        {
            GameController.answerValidation();
            if(GameController.currentState == GameState.Win)
            {
            
                field.text = "Good Job!";
                field.color =Color.green;
            }
            else if(GameController.currentState == GameState.Lose)
            {    field.text = "Sorry, you lose!";
                 field.color = Color.red;
            }
            else if(GameController.currentState == GameState.Attempt)
            {
                field.text = "Oops, wrong guess! Please try again.";
                field.color = Color.red;
            }
            
        }
        else
        {
            if(WordValidation.isWrongLength)
                field.text = "Please input 5 letter!";
            else if(!WordValidation.isEnglish)
                field.text = "It is not a English word!";
            field.color =Color.red;
        }
        isCountdown = true;
        timer = 2; 
    }
    public void showFeedbackHighLight()
    {
        if(WordValidation.userAnswer != null)
        {
            for(int i = 0; i < WordValidation.userAnswer.Length; i++)
            {
                GameObject highLight;
                if(WordValidation.userAnswer[i] == WordSelection.randomWord[i])
                {
                    //WordValidation.checkArray[i] = 1;
                    highLight = Instantiate(greenFrame, WordValidation.InputObject[i].transform);
                    hightLightObject.Add(highLight);
                }
                else if(WordValidation.userAnswer[i] != WordSelection.randomWord[i] && WordSelection.randomWord.Contains(WordValidation.userAnswer[i]))
                {
                    //WordValidation.checkArray[i] = 2;
                    highLight = Instantiate(yellowFrame, WordValidation.InputObject[i].transform);
                    hightLightObject.Add(highLight);
                }
                else if(WordValidation.userAnswer[i] != WordSelection.randomWord[i] && !WordSelection.randomWord.Contains(WordValidation.userAnswer[i]))
                {
                    //WordValidation.checkArray[i] = 3;
                    highLight = Instantiate(redFrame, WordValidation.InputObject[i].transform);
                    hightLightObject.Add(highLight);
                }
                //hightLightObject.Add(highLight);
            }
            WordValidation.userAnswer = "";
        }
        
    }

}

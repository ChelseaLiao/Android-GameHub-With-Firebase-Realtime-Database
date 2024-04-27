using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    Lose,
    Win,
    Attempt,
    Restart
}
public class GameController : MonoBehaviour
{
    public int maxAttempt = 5;
    public static int remainingAttempt;
    public static bool isAttemptChange;
    bool isRestart;

    public static GameState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.Attempt;
        remainingAttempt = maxAttempt;
    }

    // Update is called once per frame
    void Update()
    {

        switch(currentState)
        {

            // case GameState.Lose:
            // {
            //     submitButton.SetActive(false);
            //     nextRoundButton.SetActive(true);
            //     break;
            // }
            // case GameState.Win:
            // {
            //     submitButton.SetActive(false);
            //     nextRoundButton.SetActive(true);
            //     break;
            // }
            case GameState.Restart:
            {
                
                FirebaseInitialization.isInitialized = true;
                remainingAttempt = maxAttempt;
                WordValidation.userAnswer = "";
                WordValidation.isWrongLength = true;
                WordValidation.isEnglish = false;
                isAttemptChange = true;
                isRestart = true;
                foreach(var inputField in WordValidation.InputObject)
                {
                    TMP_InputField input = inputField.GetComponent<TMP_InputField>();
                    input.text = "";
                }
                break;
            }
            // case GameState.Attempt:
            // {
            //     submitButton.SetActive(true);
            //     nextRoundButton.SetActive(false);
            //     break;
            // }
        }
        if(isRestart == true)
        {
            currentState = GameState.Attempt;
            Debug.Log(currentState);
            isRestart = false;
        }
        
    }
    public static void answerValidation()
    {
        if(WordValidation.userAnswer != null)
        {
            if(WordValidation.userAnswer == WordSelection.randomWord)
            {
                currentState = GameState.Win;
            }
            else
            {
                remainingAttempt -= 1;
                currentState = GameState.Attempt;
                isAttemptChange = true;
                if(remainingAttempt == 0)
                    currentState = GameState.Lose;
            }
            Debug.Log(currentState);
        }
    }


}

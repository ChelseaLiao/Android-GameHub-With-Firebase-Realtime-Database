using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button : MonoBehaviour
{
    public GameObject submitButton;
    public GameObject nextRoundButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.currentState == GameState.Win || GameController.currentState == GameState.Lose)
        {
            Debug.Log("you are win");
            submitButton.SetActive(false);
            nextRoundButton.SetActive(true);
        }
        if(GameController.currentState == GameState.Attempt)
        {
            submitButton.SetActive(true);
            nextRoundButton.SetActive(false);
        }
    }


    public void nextRoundButtonEvent()
    {
        GameController.currentState = GameState.Restart;
        Debug.Log(GameController.currentState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Attempt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        getRemainingAttempts();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.isAttemptChange)
            getRemainingAttempts();
    }
    public void getRemainingAttempts()
    {
        int number = GameController.remainingAttempt;
        this.GetComponent<TextMeshProUGUI>().text = number.ToString();
        GameController.isAttemptChange = false;
    }
}

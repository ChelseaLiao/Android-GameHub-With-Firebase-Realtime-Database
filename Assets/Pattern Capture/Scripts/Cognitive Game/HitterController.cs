using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class HitterController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private UserFireDatabse userFirebase;
    public TextMeshProUGUI feedbackText, scoreText;
    public float feedbackDisplayTime = 1.0f;
    float timer;
    public GameObject nextGameButton;
    public GameObject showLeaderBoardButton;
    public static int hitTime = 0;
    public static float reactionTime;
    bool isCountdown = false;
    // Start is called before the first frame update
    void Start()
    {
        nextGameButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Some UIs are invisible when a new level start 
        if(CognitiveGameController.isRefresh)
        {
            feedbackText.text = "";
            showLeaderBoardButton.SetActive(false);
            nextGameButton.SetActive(false);
            CognitiveGameController.isRefresh = false;
        }
        //The operational logic during playing
        if(!CognitiveGameController.gameIsPaused)
        {
            //Set a laser pointer follows with mouse, should be replaced by a direction rocker
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 3f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = worldPosition;

            //Ray cast generated for hitting the target when left clicking the mouse
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo))
                {
                    //The number of time clicking a object
                    hitTime += 1;
                    Debug.Log("hitTime:"+hitTime);
                    //Correct response processing
                    if(hitInfo.collider.gameObject.tag == "Target")
                    {
                        reactionTime = CognitiveGameController.gameTimer;
                        Debug.Log("Your RT is:"+reactionTime);
                        feedbackText.text = "Correct Answer!";
                        feedbackText.color = Color.green;
                        Debug.Log("Your scores at this level:"+ScoringSystem.getNewScores());
                        ScoringSystem.totalScores += ScoringSystem.getNewScores();
                        Debug.Log("Total Scores:"+ScoringSystem.totalScores);
                        scoreText.text = "Score:"+ Environment.NewLine + ScoringSystem.totalScores.ToString();
                        CognitiveGameController.PauseGame();
                        userFirebase.writeCognitiveGameScores(CurrentUserDataProcessing.currentUserID, ScoringSystem.totalScores);
                        showLeaderBoardButton.SetActive(true);
                        nextGameButton.SetActive(true);
                    }
                    //Wrong response processing
                    else
                    {
                        feedbackText.text = "Oh no! Not this one!";
                        feedbackText.color = Color.red;
                        isCountdown = true;
                        timer = feedbackDisplayTime;                         
                    }
                    
                }
                
            }
            //Display the feedback text of wrong response for 1s
            if(isCountdown)
            {
                if(timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    feedbackText.text = "";
                    isCountdown = false;
                }
            }
            
        }
        // if(UserFireDatabse.isRankingRefresh)
        //     showLeaderBoardButton.SetActive(true);
        

    }

    
}

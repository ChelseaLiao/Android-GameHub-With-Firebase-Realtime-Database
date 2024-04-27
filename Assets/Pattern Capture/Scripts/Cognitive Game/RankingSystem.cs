using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using UnityEngine;
using System.Text;
using TMPro;
using System;

public class RankingSystem : MonoBehaviour
{
    [SerializeField] public CognitiveGameController gameController;
    [SerializeField] private UserFireDatabse userFirebase;
    public TextMeshProUGUI rankingResult;
    //public static bool isLeaderBoadUpdate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateLeaderBoard()
    {
        if(UserFireDatabse.CognitiveGameRanking != null)
            rankingResult.text = "User            Score\n" + UserFireDatabse.CognitiveGameRanking;
        else
            Debug.LogError("ranking is null");

        //isLeaderBoadUpdate = true;

    }
    //Need to find out the way for descending ranking
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    static float accuracy;
    static float rt;
    static int baseScores;
    static int scoresOfLevel;
    public static int totalScores = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //scores of this level should be "base scores of this leveel + 100 x (1/click times for this level)/the seconds for searching"
    public static int getNewScores()
    {
        accuracy = 1.0f / HitterController.hitTime;
        Debug.Log(accuracy);
        rt = HitterController.reactionTime;
        scoresOfLevel = (int)(getCurrentbaseScores() + accuracy / rt * 100); 
        return scoresOfLevel;
    }
    //the base scores for each level
    public static int getCurrentbaseScores()
    {
        int currentBaseScores = 5 * LevelController.LevelCount;
        baseScores = currentBaseScores;
        return baseScores;
    }
}

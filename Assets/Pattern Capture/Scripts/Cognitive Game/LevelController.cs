using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static int LevelCount = 1;
    public List<GameObject> Targets;
    public GameObject hintArea;
    public List<GameObject> hintOfAllLevel;
    GameObject hintOfCurrentLevel;
    public static List<GameObject> currentDistractors;
    public static GameObject currentTarget;
    [SerializeField] public CognitiveGameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Next game button event
    public void goToNextLevel()
    {
        if(LevelCount < Targets.Count)
        {
            LevelCount += 1;
            gameController.UpdateGame();
        }
    }
    //Decide the patterns for each level
    public void patternControll()
    {
        currentTarget = Targets[LevelCount-1];
        currentDistractors = currentTarget.transform.GetComponent<TargetToDistractors>().Distractors;
    }
    //Update the task question and the speed of moving objects 
    public void UpdateLevel()
    {
        if(hintOfCurrentLevel != null)
            Destroy(hintOfCurrentLevel);
        hintOfCurrentLevel = Instantiate(hintOfAllLevel[LevelController.LevelCount-1], hintArea.transform.position, Quaternion.identity);
        patternControll();
        ObjectController.speed *= LevelCount;
        Debug.Log("speed updated to"+ObjectController.speed);
    }

}

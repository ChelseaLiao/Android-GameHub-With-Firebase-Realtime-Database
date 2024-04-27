using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CognitiveGameController : MonoBehaviour
{
    //List<GameObject> objects;
    public GameObject BoundingBox;
    public GameObject leaderBoard;
    public static bool gameIsPaused = false;
    [SerializeField] private LevelController levelController;
    [SerializeField] private RankingSystem ranking;
    [SerializeField] private UserFireDatabse userFirebase;
    BoxCollider bc;
    GameObject target;
    public List<GameObject> distractors; 
    public static bool isRefresh = false;
    public static float gameTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        bc = BoundingBox.GetComponent<BoxCollider>();
        levelController.UpdateLevel();
        UpdateGame();
    }

    // Update is called once per frame
    void Update()
    {
        //set timer for the reaction time
        gameTimer += Time.deltaTime;
   
    }
    //Objects are spawned at the random coordinations within a bounding box
    void RandomSpawn()
    {
        Vector3 targetPos = new Vector3(Random.Range(bc.bounds.min.x, bc.bounds.max.x), Random.Range(bc.bounds.min.y, bc.bounds.max.y), 1);
        target = Instantiate(LevelController.currentTarget, targetPos, LevelController.currentTarget.transform.rotation);

        foreach(var gameObject in LevelController.currentDistractors)
        {
            Vector3 distractorPos = new Vector3(Random.Range(bc.bounds.min.x, bc.bounds.max.x), Random.Range(bc.bounds.min.y, bc.bounds.max.y), 1);
            GameObject dis = Instantiate(gameObject, distractorPos, gameObject.transform.rotation);
            distractors.Add(dis);
        }
        
    }
    //Pause game when the target is found
    public static void PauseGame()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    //Game start with data reset
    public void StartGame()
    {
        //Initialize user data once starts the game 
        //database.writeNewUser("uid_02", "You", 0);
        Debug.Log("Game start!");
        Time.timeScale = 1f;
        gameIsPaused = false;
        leaderBoard.SetActive(false);
        gameTimer = 0;
        HitterController.hitTime = 0;
    }
    //Destory the objects form last level
    void UpdateItem()
    {
        if(target != null)
            Destroy(target);
        if(distractors != null)
        {
            foreach(var dis in distractors)
                Destroy(dis);
        }
            
        RandomSpawn();
    }
    public void UpdateGame()
    {
        levelController.UpdateLevel();
        UpdateItem();
        StartGame();
        isRefresh = true;
    }
    public void showLeaderBoard()
    {
        leaderBoard.SetActive(true);
        ranking.updateLeaderBoard();
    }
}

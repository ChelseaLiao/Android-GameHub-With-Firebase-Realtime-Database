using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }    
    public void backToStartPage()
    {
        UserFireDatabse.userID = null;
        UserFireDatabse.isValidate = false;
        SceneManager.LoadScene(0);
    }
    public void goToSignUp()
    {
        SceneManager.LoadScene(1);
    }
    public void goToHomePage()
    {
        SceneManager.LoadScene(2);
    }
    public void goToSignIn()
    {
        SceneManager.LoadScene(3);
    }
    public void startWordleLike()
    {
        SceneManager.LoadScene(4);
    }
    public void startCognitiveGame()
    {
        SceneManager.LoadScene(5);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

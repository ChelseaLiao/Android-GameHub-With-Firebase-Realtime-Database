using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GetUserName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //inputField = this.gameObject.GetComponent<TMP_InputField>();
    }
    public void goToGameScene()
    {
        SceneManager.LoadScene(6);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

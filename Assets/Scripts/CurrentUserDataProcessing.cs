using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentUserDataProcessing : MonoBehaviour
{
    public static string currentUserID;
    public static string currentUserName;
    public GameObject userInfoBar;
    // Start is called before the first frame update
    void Start()
    {
        currentUserID = UserDataProcessing.registeredUserID;
        //currentUserID = UserFireDatabse.userID;
        currentUserName = UserDataProcessing.registeredUserName;
        userInfoBar.GetComponent<TextMeshProUGUI>().text = "Welcome! " + currentUserID + ": " + currentUserName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UserDataProcessing : MonoBehaviour
{
    [SerializeField] private GameObject userNameinputField;
    [SerializeField] private GameObject userPasswordinputField;
    [SerializeField] private UserFireDatabse userFirebase;
    [SerializeField] private SceneManaging sceneManaging;
    string newUserName;
    string newUserPassword;
    public static string registeredUserID;
    public static string registeredUserName;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void getUserRegisterData()
    {
        string inputName = userNameinputField.GetComponent<TMP_InputField>().text;
        //TODO: if input validated
        newUserName = inputName;
        string inputPassword = userPasswordinputField.GetComponent<TMP_InputField>().text;
        //TODO: if input validated
        newUserPassword = inputPassword;
        userFirebase.writeNewUser(newUserName,newUserPassword);
        //registeredUserID = UserFireDatabse.userID; invalidation because it invoked before writeNewUser method
        registeredUserName = newUserName;
        //sceneManaging.goToHomePage();
    }
    public void getUserSignInData()
    {
        string InputUserID = userNameinputField.GetComponent<TMP_InputField>().text;
        string InputPassword = userPasswordinputField.GetComponent<TMP_InputField>().text;
        userFirebase.validateSignInData(InputUserID, InputPassword);          
    }
    // Update is called once per frame
    void Update()
    {
        if(UserFireDatabse.userID != null)
        {
            registeredUserID = UserFireDatabse.userID;
            sceneManaging.goToHomePage();
        }
        if(UserFireDatabse.isValidate)
        {
            //registeredUserID = UserFireDatabse.userID;
            registeredUserName = UserFireDatabse.userName;
            sceneManaging.goToHomePage();
        }
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public string username;
    public string password;
    //public static float speed;

    public UserData() {
        Debug.Log(username + " "+ password);
    }

    public UserData(string username, string password) {
        this.username = username;
        this.password = password;
    }
}

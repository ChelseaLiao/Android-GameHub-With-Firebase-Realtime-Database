using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string username;
    public int scores;
    //public static float speed;

    public User() {
        
    }

    public User(string username, int scores) {
        this.username = username;
        this.scores = scores;
        //this.speed = speed;
    }
}

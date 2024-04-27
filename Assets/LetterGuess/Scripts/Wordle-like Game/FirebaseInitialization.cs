using Firebase;
using Firebase.Database;
using UnityEngine;
using System;
using System.Collections.Generic;

public class FirebaseInitialization : MonoBehaviour
{
    public static DatabaseReference databaseReference;
    public static bool isInitialized = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {

    }
    public void initializedFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted && !task.IsFaulted && task.Result == DependencyStatus.Available)
            {
                try
                {
                    //Initialize the word data base 
                    FirebaseDatabase database = FirebaseDatabase.GetInstance("https://wordle-like-default-rtdb.europe-west1.firebasedatabase.app/");
                    databaseReference = database.RootReference;
                }
                catch (Exception e)
                {
                    Debug.Log("Gotacha! " + e.Message);
                    if (databaseReference == null)
                        Debug.Log("databaseReference is null");
                    throw e;
                }
                if(databaseReference != null)
                {
                    Debug.Log("database is initialized!");
                    //getWordfromDatabase();
                    isInitialized = true;
                }
                else
                    Debug.LogError("database is null");
            }
            else
            {
                Debug.LogError("Failed to initialize Firebase: " + task.Exception);
            }
        });
        
    }
    //Get all words' questions and values from database 
    public void getWordfromDatabase()
    {
        //int randomOrder = UnityEngine.Random.Range(0, 3);
        //Debug.Log(randomOrder);
        databaseReference.Child("words").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Failed to fetch third group data from Firebase: " + task.Exception);
                return;
            }
            else
                Debug.Log("Fetch data");
            DataSnapshot groupSnapshot = task.Result;
            List<string> wordValue = new List<string>();
            List<string> wordQuestion = new List<string>();
            // Loop through the children of the group snapshot to access individual data elements
            foreach (var childSnapshot in groupSnapshot.Children)
            {
                Dictionary<string, object> wordData = (Dictionary<string, object>)childSnapshot.Value;

                string value = Convert.ToString(wordData["value"]);
                wordValue.Add(value);
                string question = Convert.ToString(wordData["question"]);
                wordQuestion.Add(question);
            }
        });
    }


}

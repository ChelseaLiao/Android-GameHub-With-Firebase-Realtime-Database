using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections.Generic;

public class WordSelection : MonoBehaviour
{
    [SerializeField] public FirebaseInitialization database;
    public static string randomWord, randomQuestion;
    public static bool isRefresh = false;
    System.Random random;
    // Start is called before the first frame update
    void Start()
    {
        database.initializedFirebase();
        random = new System.Random();

    }

    // Update is called once per frame
    void Update()
    {
        if(FirebaseInitialization.isInitialized)
        {    
            getWordfromDatabase(FirebaseInitialization.databaseReference);
            FirebaseInitialization.isInitialized = false;
        }
    }
    public void getWordfromDatabase(DatabaseReference databaseReference)
    {
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
            int randomOrder = random.Next(0, wordValue.Count);
            randomWord = wordValue[randomOrder];
            randomQuestion = wordQuestion[randomOrder];
            Debug.Log(wordValue[randomOrder]+" "+wordQuestion[randomOrder]);
            isRefresh = true;
        });
    }
    
}

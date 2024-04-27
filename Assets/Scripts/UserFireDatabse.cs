using Firebase;
using Firebase.Database;
using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

public class UserFireDatabse : MonoBehaviour
{
    DatabaseReference databaseReference;
    public static int currentUserOrder;
    public static string userID;
    public static string userName;
    public static bool isValidate = false;
    public static bool isRankingRefresh = false;
    public static string CognitiveGameRanking;
    // Start is called before the first frame update
    void Start()
    {
        initialzedFirebase();
        
    }
    void Update()
    {

    }
    public void initialzedFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted && !task.IsFaulted && task.Result == DependencyStatus.Available)
            {
                try
                {
                    //databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
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
    public void writeNewUser(string username, string password)
    {
        if(databaseReference != null)
        {
            databaseReference.Child("users").GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Exists)
                    {
                        currentUserOrder = (int)snapshot.ChildrenCount + 1;
                        Debug.Log("current number of users"+ (int)snapshot.ChildrenCount);
                    }
                    else
                    {
                        currentUserOrder = 1;
                    }
                    userID = "user_" + currentUserOrder.ToString();
                    UserData userData = new UserData(username, password);
                    Debug.Log(userData.username + userData.password);
                    string json = JsonUtility.ToJson(userData);
                    Debug.Log("Your user id:"+" "+userID);
                    databaseReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
                }
            });
        }
        else
            Debug.LogError("database reference is null");
        
    }
    public void validateSignInData(string InputUserID, string InputPassword)
    {
        
        if(databaseReference != null)
        {
            
            databaseReference.Child("users").Child(InputUserID).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    DataSnapshot snapshot = task.Result;
                    if (snapshot.Exists)
                    {
                        Dictionary<string, object> userData = (Dictionary<string, object>)snapshot.Value;
                        string savedPassword = Convert.ToString(userData["password"]);
                        if (savedPassword == InputPassword)
                        {
                            Debug.Log("Sign in success!");
                            userID = InputUserID;
                            userName = Convert.ToString(userData["username"]);
                            isValidate = true;
                        }
                        else
                        {
                            Debug.LogError("Password does not match for user " + InputUserID);
                        }
                    }
                    else
                    {
                        Debug.LogError("User ID " + InputUserID + " not found in the database.");
                    }
                }
                else
                {
                    Debug.LogError("database reference is not found!");
                }
            });
        }
        else
        {
            Debug.LogError("member databaseReference is null!");
        }
    }

    public void writeCognitiveGameScores(string currentUserID, int scores)
    {
        if(databaseReference != null)
        {
            //write scores to database
            databaseReference.Child("users").Child(currentUserID).GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    Debug.Log("write scores!");
                    databaseReference.Child("users").Child(currentUserID).Child("cognitive game").Child("scores").SetValueAsync(scores);
                    getRanking();
                }
                else
                {
                    Debug.LogError("current user id is not found!");
                }
            });
            
        }
    }
    private void getRanking()
    {
        //get ranking
            databaseReference.Child("users").GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    DataSnapshot snapshot = task.Result;
                    Dictionary<string, int> originalResult = new Dictionary<string, int>();
                    StringBuilder resultString = new StringBuilder();
                    foreach(var childSnapshot in snapshot.Children)
                    {
                        if (childSnapshot.Child("cognitive game").Exists)
                        {
                            DataSnapshot cognitiveGameSnapshot = childSnapshot.Child("cognitive game");
                            Dictionary<string, object> cogintiveGameUserData = (Dictionary<string, object>)cognitiveGameSnapshot.Value;
                            int score = Convert.ToInt32(cogintiveGameUserData["scores"]);
                            Dictionary<string, object> userData = (Dictionary<string, object>)childSnapshot.Value;
                            string userName = Convert.ToString(userData["username"]);
                            originalResult.Add(userName,score);
                            Debug.Log(userName +" "+score);
                        }
                    }
                    List<KeyValuePair<string, int>> rankingResult = new List<KeyValuePair<string, int>>(originalResult);
                    rankingResult.Sort((x, y) => y.Value.CompareTo(x.Value));
                    foreach (var result in rankingResult)
                    {
                        resultString.AppendLine(result.Key + "        " + result.Value);
                    }
                    CognitiveGameRanking = resultString.ToString();
                    isRankingRefresh = true;
                    Debug.Log("ranking result:"+CognitiveGameRanking);
                }
                else
                {
                    Debug.LogError("database reference is not found!");
                }
            });
    }

}

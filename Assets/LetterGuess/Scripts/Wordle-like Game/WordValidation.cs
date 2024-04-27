using UnityEngine;
using NetSpell.SpellChecker;

public class WordValidation : MonoBehaviour
{
    string originalWord = "";
    public static bool isWrongLength;
    public static bool isEnglish;
    public static GameObject[] InputObject;
    public static string userAnswer;
    //public static int[] checkArray;
    //private SpellChecker spellChecker;
    //string dic_Path;

    void Start()
    {
        InputObject = GameObject.FindGameObjectsWithTag("letter");
        //checkArray = new int[5];
    }

    public string getOriginalWord()
    {
        string word = "";
        foreach(var inputField in InputObject)
        {
            GetUserInput input = inputField.GetComponent<GetUserInput>();
            word += input.validatedInputLetter;
        }
        return word;
    }

    public void getValidatedWord()
    {
        originalWord = getOriginalWord();

        NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary(); 
        oDict.DictionaryFile = Application.persistentDataPath + "/en-GB.dic";
// #if UNITY_EDITOR
//         oDict.DictionaryFile = Application.dataPath + "/en-GB.dic";
// #endif
//         oDict.DictionaryFile = Application.persistentDataPath + "/en-GB.dic"; 
        oDict.Initialize();
        string wordToCheck = originalWord;
        Debug.Log(wordToCheck);
        NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling(); 

        oSpell.Dictionary = oDict;
        if(wordToCheck.Length < 5)
        {
            isWrongLength = true;
        }
        else
        {
            isWrongLength = false;
            if(!oSpell.TestWord(wordToCheck))
            {
                //originalWord = "";
                isEnglish = false;
            }
            else
            {
                isEnglish = true;
                userAnswer = wordToCheck;
                Debug.Log("It is a English word");
            }
        }
    } 

}

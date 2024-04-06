using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public List<string> PlayerName;
    public int Round;
    public int CurrentHighScore;
    public List<int> HighScore;
    public List<string> TextToDisplay; 
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void AddName(string name, int score)
    {
        
        if (PlayerName.Count > 4 && HighScore.Count > 4)
        {
            PlayerName.RemoveAt(0);
            HighScore.RemoveAt(0);
        }
        PlayerName.Add(name);
        HighScore.Add(score);
        Debug.Log("Run");
    }

    public bool ScoreCompare(int score)
    {
        if(HighScore.Count != 0 && HighScore.Count <= 5)
        {
            for (int i = 0; i < HighScore.Count; i++)
            {
                if (score > CurrentHighScore)
                {
                    CurrentHighScore = score;
                    return true;
                }
            }
            return false;
        }
        else if(HighScore.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }    
    }
}

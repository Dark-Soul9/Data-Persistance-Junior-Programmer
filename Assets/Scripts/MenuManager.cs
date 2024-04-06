using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

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
        LoadCurrentHighScore();
        LoadScore();
        LoadName();
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
    [System.Serializable]
    class SaveData
    {
        public List<int> HighScore;
        public List<string> PlayerName;
        public int CurrentHighScore;
    }
    public void SaveScore()
    {
        SaveData dataScore = new SaveData();
        dataScore.HighScore = HighScore;
        string jsonScore = JsonUtility.ToJson(dataScore);
        File.WriteAllText(Application.persistentDataPath + "/HighScore.json", jsonScore);
    }
    public void SaveName()
    {
        SaveData dataName = new SaveData();
        dataName.PlayerName = PlayerName;
        string jsonName = JsonUtility.ToJson(dataName);
        File.WriteAllText(Application.persistentDataPath + "/PlayerName.json", jsonName);
    }
    
    public void SaveCurrentHighScore()
    {
        SaveData dataHighScore = new SaveData();
        dataHighScore.CurrentHighScore = CurrentHighScore;
        string jsonHighScore = JsonUtility.ToJson(dataHighScore);
        File.WriteAllText(Application.persistentDataPath + "/CurrentHighScore.json", jsonHighScore);
    }

    public void LoadCurrentHighScore()
    {
        string pathHighScore = Application.persistentDataPath + "/CurrentHighScore.json";
        if (File.Exists(pathHighScore))
        {
            string jsonHighScore = File.ReadAllText(pathHighScore);
            SaveData dataHighScore = JsonUtility.FromJson<SaveData>(jsonHighScore);
            CurrentHighScore = dataHighScore.CurrentHighScore;
        }
    }

    public void LoadName()
    {
        string pathName = Application.persistentDataPath + "/PlayerName.json";
        if (File.Exists(pathName))
        {
            string jsonName = File.ReadAllText(pathName);
            SaveData dataName = JsonUtility.FromJson<SaveData>(jsonName);
            PlayerName = dataName.PlayerName;
        }
    }

    public void LoadScore()
    {
        string pathScore = Application.persistentDataPath + "/HighScore.json";
        if (File.Exists(pathScore))
        {
            string jsonScore = File.ReadAllText(pathScore);
            SaveData dataScore = JsonUtility.FromJson<SaveData>(jsonScore);
            HighScore = dataScore.HighScore;
        }
    }

    public void ResetScore()
    {
        string pathName = Application.persistentDataPath + "/PlayerName.json";
        string pathScore = Application.persistentDataPath + "/HighScore.json";
        string pathCurrentHighscore = Application.persistentDataPath + "/CurrentHighScore.json";
        File.Delete(pathCurrentHighscore);
        File.Delete(pathName);
        File.Delete(pathScore);
        CurrentHighScore = 0;
        HighScore.Clear();
        PlayerName.Clear();
    }
}

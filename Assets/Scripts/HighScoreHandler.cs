using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreHandler : MonoBehaviour
{
    public TextMeshProUGUI[] TextToDisplay;
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (MenuManager.Instance.HighScore.Count <= 5)
        {
            for (int i = 0; i < MenuManager.Instance.HighScore.Count; i++)
            {
                TextToDisplay[i].text = "HighScore By " + MenuManager.Instance.PlayerName[i] + " : " + MenuManager.Instance.HighScore[i];
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                TextToDisplay[i].text = "HighScore By " + MenuManager.Instance.PlayerName[i] + " : " + MenuManager.Instance.HighScore[i];
            }
        }
    }
}

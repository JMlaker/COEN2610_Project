using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void menuStart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Awake()
    {
        if (this.gameObject.name == "ScoreMenu")
        {
            var Score = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
            Score.text = Regex.Replace(Score.text, "\\d+", PlayerPrefs.GetInt("score").ToString());
        }
        if (this.gameObject.name == "MainMenu")
        {
            var pastScore = GameObject.Find("PastScore").GetComponent<TMP_Text>();
            pastScore.text = Regex.Replace(pastScore.text, "\\d+", PlayerPrefs.GetInt("score").ToString());
        }
    }
}

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
        PlayerPrefs.SetInt("score", 0);
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
            var Score = GameObject.Find("ScoreText").GetComponent<TMP_Text>().text;
            GameObject.Find("ScoreText").GetComponent<TMP_Text>().text = Regex.Replace(Score, "\\d+", PlayerPrefs.GetInt("score").ToString());
        }
    }
}

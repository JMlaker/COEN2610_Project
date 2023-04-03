using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void simpleStart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void advancedStart()
    {
        if (this.gameObject.name == "interimMenu")
        {
            TMP_Dropdown typeDrop = GameObject.Find("ModeDrop").GetComponent<TMP_Dropdown>();
            TMP_Dropdown modeDrop = GameObject.Find("DifficultyDrop").GetComponent<TMP_Dropdown>();
            PlayerPrefs.SetInt("type", typeDrop.value);
            PlayerPrefs.SetInt("mode", modeDrop.value);
            Debug.Log("Type set to: " + typeDrop.options[PlayerPrefs.GetInt("type")].text);
            Debug.Log("Mode set to: " + modeDrop.options[PlayerPrefs.GetInt("mode")].text);
        }
        SceneManager.LoadScene("MainGame");
    }

    public void menuInterim()
    {
        SceneManager.LoadScene("InterimGame");
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
        if (this.gameObject.name == "interimMenu")
        {
            GameObject.Find("ModeDrop").GetComponent<TMP_Dropdown>().SetValueWithoutNotify(PlayerPrefs.GetInt("type"));
            GameObject.Find("DifficultyDrop").GetComponent<TMP_Dropdown>().SetValueWithoutNotify(PlayerPrefs.GetInt("mode"));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("Exitting...");
            Application.Quit();
        }

        if (Input.GetKey("r"))
        {
            Debug.Log("Restarting...");
            PlayerPrefs.SetInt("score", 0);
            SceneManager.LoadScene("MainGame");
        }
    }
}

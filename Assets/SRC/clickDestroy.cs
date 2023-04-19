using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class clickDestroy : MonoBehaviour
{
    private List<int> ids;

    // Start is called before the first frame update
    void Awake()
    {
        ids = GameObject.Find("GridHolder").GetComponent<GridTest>().ids;
    }

    // Called once per click on gameObject
    void OnMouseDown()
    {
        var curScore = PlayerPrefs.GetInt("score");
        // Check if the clicked balloon has lowest id
        if (int.Parse(this.gameObject.GetComponent<Identifier>().id) == ids.Min())
        {
            PlayerPrefs.SetInt("score", curScore + 1);
            // Destroys game object
            Destroy(this.gameObject);
            // Removes the id from the list
            ids.Remove(int.Parse(this.gameObject.GetComponent<Identifier>().id));

            if (PlayerPrefs.GetInt("mode") == 1)
            {
                GameObject.Find("GridHolder").GetComponent<GridTest>().summonBalloon(ids.Max());
            }

            if (ids.Count == 0)
            {
                SceneManager.LoadScene("ScoreMenu");
                PlayerPrefs.SetInt("score", curScore + 1);
            }
        } else if (curScore > 0)
        {
            // Update score to current score - 1
            PlayerPrefs.SetInt("score", curScore - 1);
        }
        // Output "Clicked!"
        Debug.Log("Clicked on tile " + this.gameObject.GetComponent<Identifier>().id);
    }
}

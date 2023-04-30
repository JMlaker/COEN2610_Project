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
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        ids = GameObject.Find("GridHolder").GetComponent<GridTest>().ids;
        anim = this.GetComponent<Animator>();
    }

    // Called once per click on gameObject
    void OnMouseDown()
    {
        var curScore = PlayerPrefs.GetInt("score");
        // Check if the clicked balloon has lowest id
        if (int.Parse(this.gameObject.GetComponent<Identifier>().id) == ids.Min())
        {
            PlayerPrefs.SetInt("score", curScore + 1);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponentInChildren<TMP_Text>().text = "";
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
            anim.Play("pop");
            AudioSource audio = GameObject.Find("GridHolder").GetComponent<AudioSource>();
            audio.time = 0.55f;
            audio.Play();
        } else if (curScore > 0)
        {
            // Update score to current score - 1
            PlayerPrefs.SetInt("score", curScore - 1);
        }
        // Output "Clicked!"
        Debug.Log("Clicked on tile " + this.gameObject.GetComponent<Identifier>().id);
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("pop end"))
        {
            Destroy(this.gameObject);
        }
    }
}

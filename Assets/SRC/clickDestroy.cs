using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class clickDestroy : MonoBehaviour
{
    private TMP_Text scoreTextMesh;

    // Start is called before the first frame update
    void Start()
    {
        scoreTextMesh = GameObject.Find("Score").GetComponent<TMP_Text>();
    }

    // Called once per click on gameObject
    void OnMouseDown()
    {
        // Parse current score from score text
        var curScore = int.Parse(scoreTextMesh.text.Split(' ')[scoreTextMesh.text.Split(' ').Length - 1]);
        // Update score to current score + 1
        scoreTextMesh.text = scoreTextMesh.text.Split(' ')[0] + " " + (curScore + 1);
        // Update position of game object to random position in the sqaure [0, 10] X [0, 10]
        Destroy(this.gameObject);
        // Output "Clicked!"
        Debug.Log("Clicked!");
    }
}

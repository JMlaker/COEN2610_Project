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

    // Called once per click
    void OnMouseDown()
    {
        var curScore = int.Parse(scoreTextMesh.text.Split(' ')[scoreTextMesh.text.Split(' ').Length - 1]);
        scoreTextMesh.text = scoreTextMesh.text.Split(' ')[0] + " " + (curScore + 1);
        this.gameObject.transform.position = (Random.range(0, 10), Random.range(0, 10), 0);
    }
}

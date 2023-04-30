using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextMover : MonoBehaviour
{

    public TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.margin = new Vector4(Camera.main.pixelWidth / 5f, -1 * Camera.main.pixelHeight / 6.8f, 0f, 0f);
    }
}

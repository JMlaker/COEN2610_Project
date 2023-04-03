using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text timer;
    private double time = 0d;

    void Awake()
    {
        Camera cam = Camera.main;
        cam.ResetAspect();
        timer.rectTransform.position = new Vector2(cam.orthographicSize * cam.aspect, cam.orthographicSize);
        timer.rectTransform.anchoredPosition -= timer.rectTransform.sizeDelta / 2;

        time = 0d;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer.text = Regex.Replace(timer.text, "\\d+(\\.\\d+)?", time.ToString("0.##"));
    }
}

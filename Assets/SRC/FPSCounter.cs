using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Text.RegularExpressions;
using Unity.VisualScripting.FullSerializer.Internal;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text fpsCounter;

    void Awake()
    {
        Camera cam = Camera.main;
        cam.ResetAspect();
        fpsCounter.rectTransform.position = new Vector2(-1 * cam.orthographicSize * cam.aspect, cam.orthographicSize);
        fpsCounter.rectTransform.anchoredPosition += new Vector2(fpsCounter.rectTransform.sizeDelta.x, -1f * fpsCounter.rectTransform.sizeDelta.y) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        fpsCounter.text = Regex.Replace(fpsCounter.text, "\\d+", ((int)(1f / Time.unscaledDeltaTime)).ToString());
    }
}

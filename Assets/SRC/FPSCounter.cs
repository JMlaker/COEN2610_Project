using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Text.RegularExpressions;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text fpsCounter;

    // Update is called once per frame
    void Update()
    {
        fpsCounter.text = Regex.Replace(fpsCounter.text, "\\d+", ((int)(1f / Time.unscaledDeltaTime)).ToString());
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textScaler : MonoBehaviour
{
    public List<TMP_Text> texts;
    public List<float> scaler;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            texts[i].fontSize = scaler[i] * 3 * Camera.main.pixelWidth / Screen.dpi;
        }
    }
}

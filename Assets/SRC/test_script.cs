using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test_script : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Camera.main.pixelWidth);
        text.fontSize = 3 * Camera.main.pixelWidth / Screen.dpi;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

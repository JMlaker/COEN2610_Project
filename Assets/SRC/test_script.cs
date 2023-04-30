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
        Debug.Log(Camera.main.aspect);
        Debug.Log(Camera.main.pixelWidth);
        Debug.Log(Camera.main.pixelHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

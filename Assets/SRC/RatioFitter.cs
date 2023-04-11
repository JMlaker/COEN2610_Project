using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatioFitter : MonoBehaviour
{
    public List<GameObject> objectsToAspect;

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        cam.ResetAspect();
        foreach (GameObject o in objectsToAspect)
        {
            o.GetComponent<AspectRatioFitter>().aspectRatio = cam.aspect;
        }
    }
}

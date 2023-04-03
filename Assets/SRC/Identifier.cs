using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Identifier : MonoBehaviour
{
    public string id;

    void Start()
    {
        GameObject tempCanvas = new GameObject("Canvas");
        GameObject canvas = Instantiate(tempCanvas, this.transform);
        canvas.transform.localPosition = Vector3.zero;
        Canvas can = canvas.AddComponent<Canvas>();
        can.transform.localPosition = Vector3.zero;
        RectTransform canTran = can.GetComponent<RectTransform>();
        canTran.anchorMin = new Vector2(0.5f, 0.5f);
        canTran.anchorMax = new Vector2(0.5f, 0.5f);
        canTran.pivot = new Vector2(0.5f, 0.5f);
        TMP_Text idText = can.AddComponent<TextMeshProUGUI>();
        switch (PlayerPrefs.GetInt("type")) {
            /* numbers */ case 0: idText.text = id; break;
            /* letters */ case 1: idText.text = char.ToString((char)(((int.Parse(id) - 1) % 26) + 97)); break;
            default: idText.text = id; break;
        }
        idText.fontSize = 0.7f;
        idText.color = Color.black;
        idText.alignment = TextAlignmentOptions.Midline;
        Destroy(tempCanvas);
    }
}

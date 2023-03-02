using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;

public class clickDestroy : MonoBehaviour
{
    private TMP_Text scoreTextMesh;
    private List<int> ids;

    // Start is called before the first frame update
    void Start()
    {
        scoreTextMesh = GameObject.Find("Score").GetComponent<TMP_Text>();
        ids = GameObject.Find("GridHolder").GetComponent<GridManager>().ids;
    }

    // Called once per click on gameObject
    void OnMouseDown()
    {
        // Parse current score from score text
        var curScore = int.Parse(scoreTextMesh.text.Split(' ')[scoreTextMesh.text.Split(' ').Length - 1]);
        if (int.Parse(this.gameObject.GetComponent<Identifier>().id) == ids.Min())
        {
            // Update score to current score + 1
            scoreTextMesh.text = scoreTextMesh.text.Split(' ')[0] + " " + (curScore + 1);
            // Update position of game object to random position in the sqaure [0, 10] X [0, 10]
            this.gameObject.SetActive(false);
            ids.Remove(int.Parse(this.gameObject.GetComponent<Identifier>().id));
        } else if (curScore > 0)
        {
            // Update score to current score - 1
            scoreTextMesh.text = scoreTextMesh.text.Split(' ')[0] + " " + (curScore - 1);
        }
        // Output "Clicked!"
        Debug.Log("Clicked on tile " + this.gameObject.GetComponent<Identifier>().id);
    }
}

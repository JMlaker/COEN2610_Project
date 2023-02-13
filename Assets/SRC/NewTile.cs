using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewTile : MonoBehaviour
{
    public Texture2D tex;

    // Start is called before the first frame update
    void Start()
    {
        var gameObject = new GameObject();
        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        var sprite = Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(16, 16));
        spriteRenderer.color = Color.black;
        spriteRenderer.sprite = sprite;
        gameObject.transform.position = new Vector3(5, 5, 0);
        gameObject.AddComponent<clickDestroy>();
        gameObject.AddComponent<BoxCollider2D>();
        Debug.Log("Hello World!");
    }
}

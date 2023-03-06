using Gists;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Purchasing;

public class GridTest : MonoBehaviour
{
    public List<Sprite> sprites;
    public int numOfBalloons;
    public List<int> ids = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        Vector2 bottomLeft = new Vector2(-1 * cam.orthographicSize * cam.aspect + 0.5f, -1 * cam.orthographicSize + 0.5f); // new Vector2(-11.1f, -4f);
        Vector2 topRight = new Vector2(cam.orthographicSize * cam.aspect - 0.5f, cam.orthographicSize - 1f); // new Vector2(11.1f, 3f);
        List<Vector2> points = PoissonDiskSampling.Sampling(bottomLeft, topRight, (float) Math.Sqrt(2));
        for (int i = 0; i < numOfBalloons && points.Count > 0; i++)
        {
            var randPoint = points[UnityEngine.Random.Range(0, points.Count)];
            createTile(randPoint, i);
            points.Remove(randPoint);
        }
    }

    void createTile(Vector2 pos, int id)
    {
        GameObject gameObject = new GameObject();
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
        spriteRenderer.sprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
        gameObject.AddComponent<clickDestroy>();
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.AddComponent<Identifier>();
        GameObject tile = Instantiate(gameObject, this.transform);
        tile.transform.localPosition = pos;
        tile.GetComponent<Identifier>().id = (id + 1).ToString();
        ids.Add(id+1);
        Destroy(gameObject);
    }
}

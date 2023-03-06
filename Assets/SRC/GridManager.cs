/*
 * THIS FILE IS OUTDATED!
 * LOOK AT GridTest.cs FOR MOST RECENT GRID CREATOR!
*/

using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 25;
    private int cols = 11;
    private float tile_size = 1;
    public List<Sprite> sprites;
    private Camera cam;
    private GameObject[,] grid;
    public List<int> ids = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[rows-1, cols-2];
        cam = Camera.main;
        this.transform.position = new Vector3(-1 * cam.orthographicSize * cam.aspect, -1 * cam.orthographicSize, 0);
        createGrid();
        GameObject[] uGrid = UniqueGridEntries(5);
        foreach (GameObject k in uGrid)
        {
            k.SetActive(true);
            k.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool createGrid()
    {
        GameObject gameObject = new GameObject();
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
        spriteRenderer.sprite = sprites[0];
        gameObject.AddComponent<clickDestroy>();
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.AddComponent<Identifier>();
        for (int i = 1; i < rows - 1; i++)
        {
            for (int j = 1; j < cols - 2; j++)
            {
                float x = (i * tile_size);
                float y = (j * tile_size);
                GameObject tile = (GameObject)Instantiate(gameObject, this.transform);
                tile.transform.localPosition = new Vector3(x, y, 0);
                tile.gameObject.SetActive(false);
                grid[i, j] = tile;
            }
        }
        Destroy(gameObject);
        return true;
    }

    GameObject[] UniqueGridEntries(int num)
    {
        GameObject[] uGrid = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            int randX = 1;
            int randY = 1;
            while (!uGrid.Contains(grid[randX, randY]))
            {
                randX = Random.Range(1, rows - 1);
                randY = Random.Range(1, cols - 2);
                if (uGrid[i] == null)
                {
                    uGrid[i] = grid[randX, randY];
                    uGrid[i].GetComponent<Identifier>().id = i.ToString();
                    ids.Add(i);
                }
            }
        }
        return uGrid;
    }
}

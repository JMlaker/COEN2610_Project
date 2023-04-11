using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class alphaHitButton : MonoBehaviour
{
    public Image image; // The Image component that displays the texture you want to get the pixel color from
    public Camera camera; // The Camera component that renders the canvas

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)image.transform.parent, mousePos, camera, out canvasPos); // Convert mouse position to local coordinates on the canvas

            Rect rect = image.rectTransform.rect;
            float x = (canvasPos.x - rect.x) / rect.width;
            float y = (canvasPos.y - rect.y) / rect.height;

            Vector2 pixelUV = new Vector2(x, y); // Get the UV coordinates of the clicked pixel

            Texture2D texture = image.sprite.texture;
            if (texture != null) // Check if texture is not null
            {
                Color pixelColor = texture.GetPixel((int)(pixelUV.x * texture.width), (int)(pixelUV.y * texture.height)); // Get the color of the pixel at the UV coordinates
                clickDetection(pixelColor);
            }
        }
    }

    private void clickDetection(Color pixel) {
        Color pixelRounded = new Color((float)Math.Round(pixel.r, 3), (float)Math.Round(pixel.g, 3), (float)Math.Round(pixel.b, 3), 1.000f);
        List<Color> firstSet = new List<Color> {new Color(0.482f, 0.357f, 0.243f, 1.000f), new Color(0.396f, 0.576f, 0.345f, 1.000f), new Color(0.753f, 0.894f, 0.906f, 1.000f)};
        List<Color> secondSet = new List<Color> {new Color(0.463f, 0.827f, 0.890f, 1.000f), new Color(0.647f, 0.435f, 0.741f, 1.000f), new Color(0.937f, 0.220f, 0.631f, 1.000f)};
        
        if (this.gameObject.name == "mainMenu")
        {
            if (firstSet.Contains(pixelRounded))
            {
                PlayerPrefs.SetInt("type", 0);
                Debug.Log("Clicked on \"123\" button!");
                SceneManager.LoadScene("InterimGame");
            } else if (secondSet.Contains(pixelRounded))
            {
                PlayerPrefs.SetInt("type", 1);
                Debug.Log("Clicked on \"ABC\" button!");
                SceneManager.LoadScene("InterimGame");
            }
        }

        if (this.gameObject.name == "interimGame")
        {
            if (firstSet.Contains(pixelRounded))
            {
                PlayerPrefs.SetInt("mode", 1);
                Debug.Log("Clicked on \"infinite\" button!");
                SceneManager.LoadScene("MainGame");
            } else if (secondSet.Contains(pixelRounded))
            {
                PlayerPrefs.SetInt("mode", 0);
                Debug.Log("Clicked on \"timer\" button!");
                SceneManager.LoadScene("MainGame");
            }
        }
    }
}

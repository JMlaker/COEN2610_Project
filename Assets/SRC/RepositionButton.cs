using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionButton : MonoBehaviour
{
    private GameObject objectToPosition; // The game object to position
    private Camera mainCamera; // The main camera

    private void Start()
    {
        mainCamera = Camera.main;
        objectToPosition = this.gameObject;
        PositionObject();
    }

    private void PositionObject()
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f - 30f, 27.5f, mainCamera.nearClipPlane)); // Calculate the position of the bottom middle point of the screen in world coordinates
        position.z = objectToPosition.transform.position.z; // Keep the same z position as the original object
        objectToPosition.transform.position = position; // Set the position of the object
    }
}

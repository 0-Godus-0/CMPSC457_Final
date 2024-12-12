using UnityEngine;

public class CameraProjectionToggle : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>(); // Get the camera component
    }

    void Update()
    {
        // Switch between Perspective and Orthographic when pressing "P"
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (cam.orthographic)
            {
                cam.orthographic = false; // Switch to Perspective
                cam.fieldOfView = 60f;   // Set FOV for Perspective
            }
            else
            {
                cam.orthographic = true; // Switch to Orthographic
                cam.orthographicSize = 5f; // Set size for Orthographic
            }
        }
    }
}

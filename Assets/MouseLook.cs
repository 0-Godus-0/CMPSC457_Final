using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Adjust sensitivity
    public Transform playerBody;         // Reference to the character's body
    private float xRotation = 0f;        // Track vertical rotation of the camera

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game window
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera up and down (clamping to prevent flipping)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Restrict vertical movement
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the character left and right
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

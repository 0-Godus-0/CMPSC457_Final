using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Character's transform
    public Vector3 offset = new Vector3(0, 2, -4); // Adjust as needed
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 100f; // Mouse rotation speed

    private float horizontalRotation = 0f;

    void LateUpdate()
    {
        // Handle horizontal rotation with the mouse
        horizontalRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        // Calculate the desired position of the camera
        Quaternion rotation = Quaternion.Euler(0, horizontalRotation, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Keep the camera looking at the player
        transform.LookAt(target.position + Vector3.up * offset.y);
    }
}

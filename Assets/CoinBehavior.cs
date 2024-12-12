using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public float rotationSpeedY = 50f; // Speed of rotation around the Y-axis
    public float rotationSpeedZ = 30f; // Speed of rotation around the Z-axis
    public float scaleSpeed = 1f;    // Speed of scaling
    public float maxScale = 1.2f;    // Maximum scale size
    public float minScale = 0.8f;    // Minimum scale size

    private bool growing = true;

    void Update()
    {
        // Rotate the coin around the Y-axis and Z-axis
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime); // Y-axis rotation
        transform.Rotate(Vector3.forward, rotationSpeedZ * Time.deltaTime); // Z-axis rotation

        // Scale the coin up and down
        Vector3 scaleChange = Vector3.one * scaleSpeed * Time.deltaTime;

        if (growing)
            transform.localScale += scaleChange;
        else
            transform.localScale -= scaleChange;

        // Switch between growing and shrinking
        if (transform.localScale.x >= maxScale)
            growing = false;
        else if (transform.localScale.x <= minScale)
            growing = true;
    }
}

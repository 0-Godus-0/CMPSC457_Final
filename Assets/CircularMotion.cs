using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public float radius = 5f;        // Radius of the circle
    public float speed = 1f;         // Speed of the motion
    public Vector3 center;           // Center of the circle (defaults to object's start position)

    private float angle = 0f;        // Current angle in radians

    void Start()
    {
        // Default the center to the object's starting position if not set
        if (center == Vector3.zero)
            center = transform.position;
    }

    void Update()
    {
        // Increment the angle based on speed
        angle += speed * Time.deltaTime;

        // Reset angle periodically to avoid overflow
        angle %= 2 * Mathf.PI;

        // Calculate the position using the parametric equations
        float x = center.x + radius * Mathf.Cos(angle);
        float z = center.z + radius * Mathf.Sin(angle);
        float y = transform.position.y; // Maintain the original Y position

        // Update the object's position
        transform.position = new Vector3(x, y, z);
    }
}

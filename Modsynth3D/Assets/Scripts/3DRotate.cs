using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Speed of rotation (in degrees per second)
    public float rotationSpeed = 30f;

    void Update()
    {
        // Rotate the object about the x-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

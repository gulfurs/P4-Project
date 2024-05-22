using UnityEngine;

//CLASS FOR ROTATING AN OBJECT
public class RotateObject : MonoBehaviour
{
    // Speed of rotation (in degrees per second)
    public float rotationSpeed = 30f;

    void Update()
    {
        // *A POTATO FLEW AROUND MY ROOM*
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

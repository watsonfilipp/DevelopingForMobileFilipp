using UnityEngine;

public class ObjectRoll : MonoBehaviour
{
    // Adjust the speed of the roll
    public float rollSpeed = 5f;

    void Update()
    {
        // Rotate the object around its own pivot (local Z-axis) based on the roll speed
        float rotationAmount = rollSpeed * Time.deltaTime;
        transform.Rotate(Vector3.back, rotationAmount);
    }
}

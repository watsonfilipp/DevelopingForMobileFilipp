using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float movementSpeed = 2f; // Adjust the movement speed as needed

    void Update()
    {
        // Move the target along the z-axis over time
        MoveAlongZAxis();
    }

    // Method to move the target along the z-axis over time
    void MoveAlongZAxis()
    {
        transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
    }
}


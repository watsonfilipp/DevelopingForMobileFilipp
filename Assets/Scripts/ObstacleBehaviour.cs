using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles restarting game when colliding with obstacle
/// </summary>
public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("How long to wait before restarting game")]
    public float waitTime = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if we collided with the player
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            // Destroy the player
            Destroy(collision.gameObject);

            // Call the function ResetGame after waitTime has passed
            Invoke("ResetGame", waitTime);
        }
    }

    /// <summary>
    /// Will restart the currently loaded level
    /// </summary>
    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

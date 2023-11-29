using UnityEngine;

/// <summary>
/// Handles spawning a new tile and destroying this one when player reaches end
/// </summary>
public class TileEndBehaviour : MonoBehaviour
{
    [Tooltip("How long to wait before destroying the tile after reaching end")]
    public float destroyTime = 1.5f;

    private void OnTriggerEnter(Collider col)
    {
        // Check if collided with player
        if (col.gameObject.GetComponent<PlayerBehaviour>())
        {
            // Spawn new tile
            GameObject.FindObjectOfType<GameController>().SpawnNextTile();

            // Destroy this tile after delay
            Destroy(transform.parent.gameObject, destroyTime);
        }
    }
}

using UnityEngine;
using TMPro;

public class AssistantBehaviour : MonoBehaviour
{
    public string targetTag = "Target";
    public float movementSpeed = 2f;
    public float detectionRange = 5f;
    private float timer;
    public float disappearDuration = 3f;

    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component on your canvas

    void Update()
    {
        FollowTarget();

        timer += Time.deltaTime;

        // Calculate the remaining time
        float remainingTime = disappearDuration - timer;

        // Update the timer text on the canvas
        if (timerText != null)
        {
            timerText.text = Mathf.Round(remainingTime).ToString();
        }

        // Check if the timer exceeds the disappear duration
        if (timer >= disappearDuration)
        {
            Destroy(gameObject);
        }
    }

    void FollowTarget()
    {
        // Find all objects with the specified tag within the detection range
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        // Loop through each target
        foreach (GameObject target in targets)
        {
            // Checking if the target is within the detection range
            if (Vector3.Distance(transform.position, target.transform.position) < detectionRange)
            {
                // Move towards the target along the x-axis
                float newXPosition = Mathf.MoveTowards(transform.position.x, target.transform.position.x, movementSpeed * Time.deltaTime);

                // Updates the assistant's position
                transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

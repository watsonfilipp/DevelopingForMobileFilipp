using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float minXPosition = -3f;
    public float maxXPosition = 3f;
    public float smoothness = 0.8f;
    public float detectionRange = 8f; //Range to detect the player in the z-axis
    private float targetXPosition; //Target x-axis position

    private Transform player; //Reference to the player's transform
    
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        CalculateEnemyXPosition();
        SmoothMoveAlongZAxis();
    }

  
    

    //Calculating the enemy x-axis position based on the player's position
    void CalculateEnemyXPosition()
    {
        if (player != null)
        {
            //Set the current x-axis offset to the player's x position
            float currentXOffset = player.position.x;

            targetXPosition = Mathf.Clamp(transform.position.x + currentXOffset, minXPosition, maxXPosition);
        }
    }

    //Method to move the enemy smoothly along the z-axis over time
    void SmoothMoveAlongZAxis()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            float distanceToPlayer = Mathf.Abs(transform.position.z - playerObject.transform.position.z);

            if (distanceToPlayer <= detectionRange)
            {
                //Updating the player's position only when in range
                player = playerObject.transform;

                float newXPosition = Mathf.Lerp(transform.position.x, targetXPosition, smoothness * Time.deltaTime);
                
                newXPosition = transform.position.x + 0.5f * (newXPosition - transform.position.x);
                transform.Translate(new Vector3(newXPosition - transform.position.x, 0, -movementSpeed * Time.deltaTime));
            }
            else
            {
                //If the enemy is not in range, move along the z-axis only
                transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); //Should make end game condition here
        }
    }
}

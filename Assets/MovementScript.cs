using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator anim;
    private Transform parentTransform;
    private float previousXPosition;

    private bool isGoingRight;
    private bool isGoingLeft;

    void Start()
    {
        
        anim = GetComponent<Animator>(); //Get the Animator component attached to the GameObject

        parentTransform = transform.parent;

        previousXPosition = parentTransform.position.x; //Understanding the previous X position
    }

    void Update()
    {
        CheckObjectDirection(); //Checking the direction of the movement - in this case x-axis only -1.5 to 1.5
    }

    void CheckObjectDirection()
    {
        float currentXPosition = parentTransform.position.x;
        
        if (currentXPosition > previousXPosition)
        {
            isGoingRight = true; 

            isGoingLeft = false; 
        }
        else if (currentXPosition < previousXPosition)
        {            
            isGoingLeft = true;

            isGoingRight = false;
        }
        else
        {
            isGoingRight = false;
            isGoingLeft = false;
        }

        
        previousXPosition = currentXPosition; //Updating the previous X position for the next frame

        anim.SetBool("GoRight", isGoingRight); 
        anim.SetBool("GoLeft", isGoingLeft);

        //Set "Idle" to false when either "GoRight" or "GoLeft" is true
        anim.SetBool("Idle", !(isGoingRight || isGoingLeft)); 
    }
}

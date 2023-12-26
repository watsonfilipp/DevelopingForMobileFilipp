using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator anim;
    private Transform parentTransform;
    private float previousXPosition;

    private bool isGoingRight;
    private bool isGoingLeft;

    private int decimalPlaces = 1; //Number of decimal places to consider

    void Start()
    {
        anim = GetComponent<Animator>(); //Get the Animator component attached to the GameObject

        parentTransform = transform.parent;

        previousXPosition = RoundToDecimal(parentTransform.position.x, decimalPlaces); //Understanding the previous X position
    }

    void Update()
    {
        CheckObjectDirection(); //Checking the direction of the movement - in this case x-axis only
    }

    void CheckObjectDirection()
    {
        float currentXPosition = parentTransform.position.x;
        float roundedCurrentXPosition = RoundToDecimal(currentXPosition, decimalPlaces);

        if (roundedCurrentXPosition > previousXPosition)
        {
            isGoingRight = true;
            isGoingLeft = false;
        }
        else if (roundedCurrentXPosition < previousXPosition)
        {
            isGoingLeft = true;
            isGoingRight = false;
        }
        else
        {
            isGoingRight = false;
            isGoingLeft = false;
        }

        previousXPosition = roundedCurrentXPosition; //Updating the previous X position for the next frame

        anim.SetBool("GoRight", isGoingRight);
        anim.SetBool("GoLeft", isGoingLeft);

        //Set "Idle" to false when either "GoRight" or "GoLeft" is true
        anim.SetBool("Idle", !(isGoingRight || isGoingLeft));
    }
    //Rounds to decimals to make animation more logical and not trigger in place as the objects location is always slightly changing
    float RoundToDecimal(float value, int decimalPlaces)
    {
        float multiplier = Mathf.Pow(100f, decimalPlaces);
        return Mathf.Round(value * multiplier) / multiplier;
    }
}

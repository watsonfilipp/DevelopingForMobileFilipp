using UnityEngine;

/// <summary>
/// Will adjust the camera to follow and face a target
/// </summary>
public class CameraBehaviour : MonoBehaviour
{
    [Tooltip("The object the camera should be looking at")]
    public Transform target;

    [Tooltip("Camera offset from the target")]
    public Vector3 offset = new Vector3(0, 3, -6);

    void Update()
    {
        if(target != null)
        {
            // Set position to an offset of the target
            transform.position = target.position + offset;

            // Change the rotation to face target
            transform.LookAt(target);
        }
    }
}

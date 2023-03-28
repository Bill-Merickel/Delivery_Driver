using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject objectToFollow;

    // Updates the camera's position last to reduce potential latency
    void LateUpdate()
    {
        // Update the camera position while maintaining a distance in the z-direction
        transform.position = objectToFollow.transform.position + new Vector3(0, 0, -10);
    }
}

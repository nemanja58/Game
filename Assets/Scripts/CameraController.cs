using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{

    public Transform target; // The target player object
    public float smoothTime = 0.3f; // The time it takes for the camera to move to its new position
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        // Calculate the new position for the camera
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Smoothly move the camera to the new position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

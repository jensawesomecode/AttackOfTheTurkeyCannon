using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assign your player in the Inspector
    public float smoothSpeed = 5f; // Adjust to change follow speed
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Keeps camera at the right distance

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}

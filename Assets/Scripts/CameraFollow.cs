using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float damping = 2.0f;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + Vector3.up * height - target.forward * distance;
        Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = position;
        //transform.LookAt(target.position);
    }
}

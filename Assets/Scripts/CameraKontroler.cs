using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKontroler: MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;

    private Vector3 targetPosition;



    void LateUpdate()
    {
        // Track player position
        targetPosition = player.transform.position;

        // Move camera towards player
        Vector3 currentPosition = transform.position;
        targetPosition.y = currentPosition.y;
        transform.position = Vector3.Lerp(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
    }
}


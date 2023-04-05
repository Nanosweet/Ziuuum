using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;

    private void LateUpdate()
    {
        Vector3 offset = new Vector3(0, height, -distance);
        transform.position = target.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPos;
    //public float smoothSpeed = .125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerPos.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKey(KeyCode.G))
        //{
            offset = new Vector3(0, 23, -28);
            Vector3 desiredPosition = playerPos.position + offset;
            //Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = desiredPosition;
        
        //}
        //transform.position = playerPos.position;
    }
    private void LateUpdate()
    {
       // offset = new Vector3(0, 20, -120);
        //Vector3 desiredPosition = playerPos.position + offset;
        //Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPos;
    }
}

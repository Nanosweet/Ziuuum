using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] 
    private GameObject rotatePoint, punkt;

    [SerializeField]
    Transform playerPosition;
    

    


    [SerializeField]
    float offset3; /*angle*/
    // Start is called before the first frame update
    void Start()
    {
        
        //transform.position = rotatePoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Vector3.zero;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = hit.point;
        }

        if(Input.GetKey(KeyCode.C))
        {
            transform.LookAt(playerPosition);

            transform.position = new Vector3(position.x, transform.position.y, position.z);

            Debug.Log("playerPos:" + playerPosition);

            //punkt.transform.position = transform.position;
        }
        
        
    }
}

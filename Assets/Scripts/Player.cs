using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Header("Player Settings")]

    private Rigidbody rb;
    public float stopVelocity;
    [SerializeField] private float _playerForce = 0f;    


    [SerializeField] LineRenderer aimLine;
    private float _lineZPos = -0.3f;
    private float _lineYPos = 0.1f;

    bool stoi = false;
    
    [SerializeField] Text currentTime;

    
    

    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody>();
        aimLine.enabled = false;
        //rb.freezeRotation = false;
        //rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        var mousePos = ClickedPoint(); // get MousePos
        Vector3 dir2 = rb.position - mousePos;


        // Aim Linerenderer index 0 coordinates position
        Vector3 aimLineIndex0 = new Vector3(rb.transform.position.x, _lineYPos, rb.transform.position.z);
        Vector3 aimLineIndex1 = new Vector3(mousePos.x, mousePos.z, _lineZPos);
        aimLine.SetPosition(1, aimLineIndex1);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S)|| rb.velocity.magnitude < stopVelocity)
        {
            BallStopMoving();
        }
    }
    private void BallStopMoving()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


    // Pozycja myczy
    Vector3 ClickedPoint()
    {
        Vector3 position = Vector3.zero; // zmienna position = 0,0,0
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // castowanie ray od kamery do pozycji myczy na ekranie        

        RaycastHit hit = new RaycastHit();        

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = hit.point;
        }        
        return position;
    }

    private void OnMouseDown()
    {
        Vector3 startPos = ClickedPoint();
        // Kierunek = pozycja gracza - pozycja myszy      

        aimLine.enabled = true;
        aimLine.SetPosition(0, new Vector3(rb.position.x, rb.position.z, _lineZPos));

    }
    private void OnMouseUp()
    {
        Vector3 endPos = ClickedPoint();
        float _playerForce = Vector3.Distance(rb.transform.position, endPos);
        //aimLine.enabled = false;
       //rb.freezeRotation = false;
        

        Vector3 dir = GetComponent<Rigidbody>().position - endPos;
        GetComponent<Rigidbody>().AddForce(dir * _playerForce, ForceMode.Impulse );
    }



}

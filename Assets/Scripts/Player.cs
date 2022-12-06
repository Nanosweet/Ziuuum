using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force = 0f;   

    [SerializeField] Text currentTime;


    float _lineZPos = -1f;
    float _lineYPos = 0.3f;

    bool stoi = false;
    public float stopVelocity;

    public GameObject mCamera;

    [SerializeField] Transform playerPos;


    Color c1 = Color.black;
    Color c2 = Color.red;



    // Linerenderer
    [SerializeField] LineRenderer aimLine, dirLine;

    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody>();
        aimLine.enabled = false;
        rb.freezeRotation = false;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        var mousePos = ClickedPoint(); // get MousePos
        Vector3 dir2 = rb.position - mousePos;


        // Aim Linerenderer index 0 coordinates position
        Vector3 aimLineIndex0 = new Vector3(rb.transform.position.x, _lineYPos, rb.transform.position.z);
        Vector3 aimLineIndex1 = new Vector3(mousePos.x, _lineYPos, mousePos.z);
        Vector3 aimLineIndex1v2 = new Vector3(dir2.x, _lineYPos, dir2.z);
        aimLine.SetPosition(0, aimLineIndex0);

        

        if(Input.GetKey(KeyCode.Mouse0))
       {
           aimLine.SetPosition(1, -mousePos);
       }
        //aimLine.SetPosition(1, ClickedPoint());

        //dirLine.SetColors(c1,c2);

        //dirLine.SetPosition(0, rb.transform.position );
        

        //aimLine.SetPosition(0, new Vector3(rb.transform.position.x, _lineYPos, rb.transform.position.z));
        aimLine.SetPosition(1, dir2);

        


        //dirLine.SetPosition(1, dir2);

        Debug.Log("rb.velo:"+rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S)|| rb.velocity.magnitude < stopVelocity)
        {
            Stop();
        }
    }
    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        

        
       // stoi = true;
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
        Vector3 dir = GetComponent<Rigidbody>().position - startPos;

        //Transform aimStartPos = rb.transform.position.x;
        

        aimLine.enabled = true;
        aimLine.SetPosition(0, rb.transform.position);
        
        //lr.SetPosition(0, GetComponent<Rigidbody>().position);
        //lr.SetPosition(1, startPos);
    }
    private void OnMouseUp()
    {
        Vector3 endPos = ClickedPoint();
        float force = Vector3.Distance(rb.transform.position, endPos);
        aimLine.enabled = false;
        rb.freezeRotation = false;
        

        Vector3 dir = GetComponent<Rigidbody>().position - endPos;
        GetComponent<Rigidbody>().AddForce(dir * force, ForceMode.Impulse);

        //Debug.Log("Pierdolniecie: "+ rb.velocity );
    }



}

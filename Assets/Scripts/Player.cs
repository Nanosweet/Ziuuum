using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force = 0f;   

    [SerializeField] Text currentTime;

    bool stoi = false;
    public float stopVelocity;

    public GameObject mCamera;


    Color c1 = Color.black;
    Color c2 = Color.red;



    // LINERENDERER
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
        if(Input.GetKey(KeyCode.Mouse0))
       {
           aimLine.SetPosition(1, ClickedPoint());
       }
        //aimLine.SetPosition(1, ClickedPoint());

        dirLine.SetColors(c1,c2);

        dirLine.SetPosition(0, rb.transform.position );

        var x = ClickedPoint();
        Vector3 dir2 = GetComponent<Rigidbody>().position - x;


        dirLine.SetPosition(1, dir2);
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
        stoi = true;
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

        aimLine.enabled = true;
        aimLine.SetPosition(0, rb.transform.position);
        
        //lr.SetPosition(0, GetComponent<Rigidbody>().position);
        //lr.SetPosition(1, startPos);
    }
    private void OnMouseUp()
    {
        Vector3 endPos = ClickedPoint();
        aimLine.enabled = false;
        rb.freezeRotation = false;

        Vector3 dir = GetComponent<Rigidbody>().position - endPos;
        GetComponent<Rigidbody>().AddForce(dir * 1f, ForceMode.Impulse);
    }



}

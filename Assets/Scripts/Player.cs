using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force = 0f;

    private Vector3 startPos;

    [SerializeField] Text currentTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        Debug.DrawLine(Vector3.zero, new Vector3(5, 0, 0), Color.white, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Naciskasz spacje force sie inkrementuje

        //Input.GetKey

        //if(currentTime.text == "0")
        //{
        //    rb.AddForce(0,0, 2000 * Time.deltaTime);
        //}

        

        //if(Input.GetKey(KeyCode.K))
        //{
        //    rb.velocity = transform.forward * force * Time.deltaTime;
        //}
        
        //if(Input.GetKey(KeyCode.Space))
        //{
        //    force++;            
        //}
        //if(Input.GetKeyUp(KeyCode.Space))
        //{
        //    rb.AddForce(transform.forward * force * 5 * Time.deltaTime, ForceMode.Impulse);
        //    Debug.Log("Klikles spacje " + force);
        //}
        //if(Input.GetKeyUp(KeyCode.G))
        //{
        //    transform.position = startPos;
        //    rb.AddForce(0,0,0);
        //}

        

        //Debug.DrawLine(Vector3.zero, Vector3.forward * 100);
        if (Physics.Raycast(Vector3.zero, Vector3.forward, Mathf.Infinity))
        {
            print("There is something in front of the object!");
        }

        Debug.Log(rb.velocity+"<<rb.velodity");
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            force = 5f;
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
            
            //ClickedPoint();
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            //rb.AddForce(transform.forward * force, ForceMode.Impulse);
            force = 0;
            //ClickedPoint();
        }

    }


    Vector3 ClickedPoint()
    {
        Vector3 position = Vector3.zero; // zmienna position = 0,0,0
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // castowanie ray od kamery do pozycji myczy

        RaycastHit hit = new RaycastHit();
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = hit.point;
        }
        Debug.Log("positgion" + position);
        return position;
    }

    private void OnMouseDown()
    {
        Vector3 startPos = ClickedPoint();
        Debug.Log("Metoda OnMouseDown>>" + startPos + "<<startPos");
    }
    private void OnMouseUp()
    {
        Vector3 endPos = ClickedPoint();
        Debug.Log("Metoda OnMouseUp>>" + endPos + "<<endPos");
    }




}

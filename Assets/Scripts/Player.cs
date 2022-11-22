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
    }

    // Update is called once per frame
    void Update()
    {
        //Naciskasz spacje force sie inkrementuje

        //Input.GetKey

        if(currentTime.text == "0")
        {
            rb.AddForce(0,0, 2000 * Time.deltaTime);
        }

        

        if(Input.GetKey(KeyCode.K))
        {
            rb.velocity = transform.forward * force * Time.deltaTime;
        }
        
        if(Input.GetKey(KeyCode.Space))
        {
            force++;            
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(transform.forward * force * 5 * Time.deltaTime, ForceMode.Impulse);
            Debug.Log("Klikles spacje " + force);
        }
        if(Input.GetKeyUp(KeyCode.G))
        {
            transform.position = startPos;
            rb.AddForce(0,0,0);
        }
    }
    



}

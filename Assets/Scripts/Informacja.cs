using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informacja : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 10f;

    public Text countdownText;

    
    //int i=10;
    // Start is called before the first frame update
    void Start()
    {        
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");
    }
}

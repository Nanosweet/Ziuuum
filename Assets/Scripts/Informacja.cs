using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informacja : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 3f;

    public Text countdownText;

    
    //int i=10;
    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<Text>();
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Odliczanie czasu 
        currentTime -= 1 * Time.deltaTime;

        // Czas na ekran
        countdownText.text = currentTime.ToString("0");

        if (countdownText.text == "0")
        {
            countdownText.text = "Start";
            countdownText.text = "";

            
        }

        Debug.Log("CurrentTime:" + countdownText.text);

        
    }
}

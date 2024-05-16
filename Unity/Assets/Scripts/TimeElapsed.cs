using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeElapsed : MonoBehaviour
{
    //start time value
    [SerializeField] float startTime;

    //Current time
    float currentTime;

    //Has the timer started
    bool timerStarted = false;

    //variable for UI text
    [SerializeField] TMP_Text timerText;

    [SerializeField] Button timerModeButton;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        timerText.text = currentTime.ToString("f2");
    }

    // Update is called once per frame
    void Update()
    {
        //        button1.gameObject.SetActive(true);

        if (timerModeButton.gameObject.activeSelf)
        {
            timerStarted = false;
        }

        else
        {
            timerStarted = true;
        }
        if (timerStarted)
        {
            currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("f2");

        }
    }
}
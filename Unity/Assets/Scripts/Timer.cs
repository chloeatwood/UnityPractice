using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //start time value
    [SerializeField] float startTime;

    //Current time
    float currentTime;

    //Has the timer started
    bool timerStarted = false;

    //variables for UI text
    [SerializeField] TMP_Text timerText;

    [SerializeField] Button timerModeButton;

    [SerializeField] TMP_Text gameOver;

    [SerializeField] TMP_Text timeRemaining;

    //[SerializeField] Button Exit, Restart;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
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
            //subtracting time
            currentTime -= Time.deltaTime;

            //time is 0
            if (currentTime <= 0)
            {
                Debug.Log("Timer reached 0");
                timerStarted = false;
                currentTime = 0;
                if (timeRemaining.gameObject.activeSelf)
                {
                    gameOver.gameObject.SetActive(true);
                    UnityEngine.Cursor.lockState = CursorLockMode.None;
                    //Find way to freeze game movement

                }
                


            }

            timerText.text = currentTime.ToString("f2");

        }
    }
}

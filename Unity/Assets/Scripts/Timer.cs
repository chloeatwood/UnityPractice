using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    //Current time
    float currentTime;

    //Has the timer started
    bool timerStarted = false;

    //variables for UI text
    [SerializeField] TMP_Text timerText;

    [SerializeField] Button timerModeButton;

    [SerializeField] TMP_Text gameOver;

    [SerializeField] TMP_Text timeRemaining;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = 60f;
        timerText.text = currentTime.ToString("f2");
        Time.timeScale = 1f;
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
                    //Showing player lost
                    gameOver.gameObject.SetActive(true);

                    //freezing time so player cannot move
                    Time.timeScale = 0;

                    //Allwing the mouse to move
                    UnityEngine.Cursor.lockState = CursorLockMode.None;
                    

                }
                


            }

            timerText.text = currentTime.ToString("f2");

        }
    }
}

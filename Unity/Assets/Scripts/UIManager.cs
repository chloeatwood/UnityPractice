using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;




public class UIManager : MonoBehaviour
{
    [SerializeField] Button startTimerMode, startExploreMode, Exit;
    [SerializeField] TMP_Text timerText, timerCount, timeElapsed, timeCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to reset the game round
    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    //Function to quit out of the application
    public void exitGame()
    {
        Application.Quit();

    }

    public void timerMode()
    {
        timerCount.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        startTimerMode.gameObject.SetActive(false);
        startExploreMode.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
    }

    public void freeMode()
    {
        timeElapsed.gameObject.SetActive(true);
        timeCount.gameObject.SetActive(true);
        startTimerMode.gameObject.SetActive(false);
        startExploreMode.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
    }




}

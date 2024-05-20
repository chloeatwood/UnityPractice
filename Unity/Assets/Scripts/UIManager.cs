using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;




public class UIManager : MonoBehaviour
{
    [SerializeField] Button startTimerMode, startExploreMode, Exit, InstructionsButton, BackButtonMainMenu, NextPage, BackPage;
    [SerializeField] TMP_Text timerText, timerCount, timeElapsed, timeCount, Instructions, Hints;
    [SerializeField] GameObject Background;

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
        InstructionsButton.gameObject.SetActive(false);
    }

    public void freeMode()
    {
        timeElapsed.gameObject.SetActive(true);
        timeCount.gameObject.SetActive(true);
        startTimerMode.gameObject.SetActive(false);
        startExploreMode.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        InstructionsButton.gameObject.SetActive(false);
    }

    public void showingInstructions()
    {
        InstructionsButton.gameObject.SetActive(false);
        BackButtonMainMenu.gameObject.SetActive(true);
        Instructions.gameObject.SetActive(true);
        Background.SetActive(true );
        NextPage.gameObject.SetActive(true);

    }

    public void backToMain()
    {
        InstructionsButton.gameObject.SetActive(true);
        BackButtonMainMenu.gameObject.SetActive(false);
        Instructions.gameObject.SetActive(false);
        Background.SetActive(false);
        NextPage.gameObject.SetActive(false);
        Hints.gameObject.SetActive(false);
        BackPage.gameObject.SetActive(false);
    }

    public void secondPageInfo()
    {
        BackButtonMainMenu.gameObject.SetActive(true);
        Background.SetActive(true);
        NextPage.gameObject.SetActive(false);
        BackPage.gameObject.SetActive(true);
        Hints.gameObject.SetActive(true);
        Instructions.gameObject.SetActive(false);
    }

    public void backAPage()
    {
        BackButtonMainMenu.gameObject.SetActive(true);
        Background.SetActive(true);
        NextPage.gameObject.SetActive(true);
        BackPage.gameObject.SetActive(false);
        Hints.gameObject.SetActive(false);
        Instructions.gameObject.SetActive(true);
    }


}

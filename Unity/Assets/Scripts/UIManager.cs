using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;




public class UIManager : MonoBehaviour
{
    [SerializeField] Button startTimerMode, startExploreMode, Exit, InstructionsButton, BackButtonMainMenu, NextPage, BackPage, Settings;
    [SerializeField] TMP_Text timerText, timerCount, timeElapsed, timeCount, Instructions, Hints, LevelText;
    [SerializeField] GameObject Background, SettingsCannvas;
    [SerializeField] AudioMixer audioMixer;


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
        Settings.gameObject.SetActive(false);
    }

    public void freeMode()
    {
        timeElapsed.gameObject.SetActive(true);
        timeCount.gameObject.SetActive(true);
        startTimerMode.gameObject.SetActive(false);
        startExploreMode.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        InstructionsButton.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
    }

    public void showingInstructions()
    {
        InstructionsButton.gameObject.SetActive(false);
        BackButtonMainMenu.gameObject.SetActive(true);
        Instructions.gameObject.SetActive(true);
        Background.SetActive(true );
        NextPage.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);


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
        SettingsCannvas.SetActive(false);
        Settings.gameObject.SetActive(true);
    }

    public void secondPageInfo()
    {
        BackButtonMainMenu.gameObject.SetActive(true);
        Background.SetActive(true);
        NextPage.gameObject.SetActive(false);
        BackPage.gameObject.SetActive(true);
        Hints.gameObject.SetActive(true);
        Instructions.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
    }

    public void backAPage()
    {
        BackButtonMainMenu.gameObject.SetActive(true);
        Background.SetActive(true);
        NextPage.gameObject.SetActive(true);
        BackPage.gameObject.SetActive(false);
        Hints.gameObject.SetActive(false);
        Instructions.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);

    }

    public void openSettings()
    {
        InstructionsButton.gameObject.SetActive(false);
        BackButtonMainMenu.gameObject.SetActive(true);
        Settings.gameObject.SetActive(false);
        Background.SetActive(true);
        SettingsCannvas.SetActive(true);
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}

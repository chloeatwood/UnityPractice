using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
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
}

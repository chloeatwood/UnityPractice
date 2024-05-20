using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
    [SerializeField] TMP_Text cheeseText;
    [SerializeField] int winAmount;
    [SerializeField] TMP_Text winner;
    [SerializeField] GameObject winningCheese;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num = int.Parse(cheeseText.text);
        if (num >= winAmount && !winningCheese.activeSelf) {

            //Showing the player they won
            winner.gameObject.SetActive(true);

            //Freezing time
            Time.timeScale = 0;

            //Allowing mouse movement
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }
}

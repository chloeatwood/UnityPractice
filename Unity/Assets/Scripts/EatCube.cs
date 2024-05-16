using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class EatCube : MonoBehaviour

{

    MovementManager movementManager;

    Transform i;

    //Current amount
    [SerializeField] int cheeseEaten;

   

    //reference variables
    [SerializeField] TMP_Text cheeseText;
    [SerializeField] GameObject capsule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i = capsule.GetComponent<Transform>();

        movementManager = capsule.GetComponent<MovementManager>();

        //print(movementManager.rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // print(collision.gameObject);
        if (collision.gameObject == capsule)
        {
            //print("hI");
            gameObject.SetActive(false);
            int num = int.Parse(cheeseText.text);
            num += 1;
            cheeseText.text = num.ToString();



        } 
    }
}

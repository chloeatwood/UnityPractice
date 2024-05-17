using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SuperCheese : MonoBehaviour
{

    [SerializeField] GameObject capsule;
    [SerializeField] int waitTime;
    [SerializeField] GameObject particles;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == capsule)
        {
            gameObject.SetActive(false);
            particles.SetActive(false);
            Invoke("superCheeseRespawn", waitTime);

            
        }
    }


    private void superCheeseRespawn()
    {
        gameObject.SetActive(true);
        particles.SetActive(true);
    }



}

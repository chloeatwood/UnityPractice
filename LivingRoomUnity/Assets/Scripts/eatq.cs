using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class eatq : MonoBehaviour
{
    int number = 0;
    [SerializeField] GameObject capsule;

    MovementManager movementManager;

    Transform i; 

    // Start is called before the first frame update
    void Start()
    {
        
        print(number);
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
        }
    }
}

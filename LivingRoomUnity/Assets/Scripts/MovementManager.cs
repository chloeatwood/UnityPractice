using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementManager : MonoBehaviour
{
    //Example Method
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Example Method
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Transform>().position = GetComponent<Transform>().position + new Vector3(-.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Transform>().position = GetComponent<Transform>().position + new Vector3(0, 0, -.1f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Transform>().position = GetComponent<Transform>().position + new Vector3(0, 0, .1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Transform>().position = GetComponent<Transform>().position + new Vector3(.1f, 0, 0);
        }


        //Need to use time.deltaTime google
        //Must rotate
        //use at least 3 different methods
        //try to find a way to rotate with mouse
    }*/

    //Method 1

    Vector3 startPos_capsule;
    public Transform transform_capsule;

    private void Awake()
    {
        startPos_capsule = transform_capsule.position;
    }

    private void Update()
    {
        MoveLeftRight();
        MoveForwardBack();
        MoveRotate();
       
    }

    void MoveLeftRight()
    {
        Vector3 vLeft = Vector3.zero;
        vLeft.x = Input.GetAxis("Horizontal");
        Vector3 v = new Vector3(vLeft.x, 0.0f, 0.0f) * Time.deltaTime * .1f;
        transform_capsule.Translate(v, Space.Self);
    }
    void MoveForwardBack()
    {
        Vector3 vForward = Vector3.zero;
        vForward.z = Input.GetAxis("Vertical");
        Vector3 v = new Vector3(0.0f, 0.0f, vForward.z) * Time.deltaTime * .1f;
        transform_capsule.Translate(v, Space.Self);
    }

    void MoveRotate()
    {
        Vector3 vRotate = Vector3.zero;
        vRotate.y = Input.GetAxis("Rotate");
        Vector3 v = new Vector3(0.0f, vRotate.y, 0.0f) * Time.deltaTime * 15.0f;
        transform_capsule.Rotate(v, Space.Self);
    }
}

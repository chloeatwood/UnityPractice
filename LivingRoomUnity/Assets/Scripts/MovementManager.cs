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

    }*/

    //Method 1

    /*
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
    }*/




    //Method 2
    /*
    public Vector2 turn;
    [SerializeField] private float speed = .1f;
    [SerializeField] private Rigidbody rb;


    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = dir * speed;



    }*/

    //Method 3
    public float speed;
    public float rotationSpeed;
    public Vector2 turn;
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = dir * speed;

    }


}




using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    }




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
    /*
    [SerializeField] float speed;
    public float rotationSpeed;
    [SerializeField] Vector2 turn;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float jumpForce = 30;
    [SerializeField] Button button;



    void Start()
    {

    }
    void Update()
    {
        

        

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");


            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);


            // Making the player be able to jump


            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            }


            var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rb.velocity = dir * speed;

            if (Input.GetMouseButton(1))
            {
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;


                if (movementDirection != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                }
                turn.x += Input.GetAxis("Mouse X");
                turn.y += Input.GetAxis("Mouse Y");
                transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);


            }
            else
            {
                UnityEngine.Cursor.lockState = CursorLockMode.None;
            }
       

    }*/
    //New Method

    //Initializing player and camera
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;

    //Adding variables
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float JumpForce;
    [SerializeField] private float superJump;
    [SerializeField] Button StartGame;
    [SerializeField] Button Exit;
    [SerializeField] Button Reset;
    [SerializeField] Button GameInfo, Settings;
    [SerializeField] private bool grounded = false;
    [SerializeField] private GameObject superCheese;
    private bool GameIsPaused = false;
    [SerializeField] private GameObject otherSuperCheese;




    //Adding input storage
    private Vector3 PlayerMovement;
    private Vector2 PlayerMouse;
    private float xRot;

    private void Update()
    {
        PlayerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));


            //Locking player movement if in beginning of game
            if (StartGame.gameObject.activeSelf)
            {

            }

            else
            {
                if (GameIsPaused == false && Input.GetKeyDown(KeyCode.Tab))
                {
                    PauseGame();
                }

                else if (GameIsPaused == false) 
                {
                    UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                    Exit.gameObject.SetActive(true);
                    Reset.gameObject.SetActive(true);
                    MovePlayer();
                    MovePlayerCamera();
                }
                else if (GameIsPaused && Input.GetKeyDown(KeyCode.Tab))
                {
                ResumeGame();
                }
            


        }
    }

    //Move player function
    private void MovePlayer()
    {
        //Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 MoveVector = transform.TransformDirection(PlayerMovement) * RunSpeed;
            PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);
        }

        else
        {
            //Walking
            Vector3 MoveVector = transform.TransformDirection(PlayerMovement) * WalkSpeed;
            PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);
         }
        

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            if (superCheese.activeSelf) 
            { 
                PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
            else
            {
                PlayerBody.AddForce(Vector3.up * superJump, ForceMode.Impulse);
            }
            if (!otherSuperCheese.activeSelf)
            {
                PlayerBody.AddForce(Vector3.up * superJump, ForceMode.Impulse);
            }
            {

            }

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    //Rotation function
    private void MovePlayerCamera()
    {
        if (Time.timeScale == 1) { 
            xRot -= PlayerMouse.y * Sensitivity;

            transform.Rotate(0f, PlayerMouse.x * Sensitivity, 0f);
            PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }
    }


    void ResumeGame()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        GameIsPaused = false;
        Cursor.visible = false;
        GameInfo.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
        
    }

    void PauseGame()
    {

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        GameIsPaused = true;
        GameInfo.gameObject.SetActive(true);
        Settings.gameObject.SetActive(true);


    }
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject playerModel;

    public GunManager theGun;

    bool controllerConnected;

    Camera mainCamera;

    // Use this for initialization
    void Start()
    {
        if(Input.GetJoystickNames().Length == 0){
            controllerConnected = false;
        }
        else
        {
            controllerConnected = true;
        }

        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LookAt();
        Firing();
    }

    /*
     * Movement and Rotation have been seperated for ease of use, to keep the player's movement direction
     * independant of the actual rotation of the player. ( if a better way is known, and is softer computationally, replace it)
     */

    // Makes the player Move dependant on the left thumbstick.
    void Movement()
    {
        if (controllerConnected)
        {
            float leftstickX = Input.GetAxis("Horizontal");
            float leftstickY = Input.GetAxis("Vertical");

            float deadZone = 0.01f;

            if (Mathf.Abs(leftstickX) > deadZone)
            {
                transform.Translate(leftstickX / 10, 0, 0);
            }
            if (Mathf.Abs(leftstickY) > deadZone)
            {
                transform.Translate(0, 0, leftstickY / 10);
            }
        }

        else
        {
            float moveSpeed = 0.1f;
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0f, 0f, moveSpeed);
            }
            else
            {
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(0f, 0f, -moveSpeed);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-moveSpeed, 0f, 0f);
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(moveSpeed, 0f, 0f);
                }
            }
        }
        
    }

    // Makes the player's Model look depending on the position of the right stick.
    void LookAt()
    {
        Vector3 playerDirection;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (controllerConnected)
        {
            float rightstickX = Input.GetAxisRaw("RightStickX");
            float rightstickY = Input.GetAxisRaw("RightStickY");

            float deadZone = 0.5f;

            playerDirection = Vector3.right * rightstickX + Vector3.forward * -rightstickY;
            if (playerDirection.sqrMagnitude > deadZone)
            {
                playerModel.transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
        }
        else
        {
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                playerModel.transform.LookAt(new Vector3(pointToLook.x, playerModel.transform.position.y, pointToLook.z));
            }
            
        }

        
    }

    void Firing()
    {
        if (controllerConnected)
        {
            float leftTrigger = Input.GetAxisRaw("LeftTrigger");
            float rightTrigger = Input.GetAxisRaw("RightTrigger");

            float deadZone = 0.1f;

            if (rightTrigger > deadZone)
            {
                theGun.firing = true;
            }
            if (rightTrigger <= deadZone)
            {
                theGun.firing = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                theGun.firing = true;
            }
            else
            {
                theGun.firing = false;
            }
        }
        
    }


    
}


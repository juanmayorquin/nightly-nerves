using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    private AudioManager audioManager;
    [SerializeField] private float speed = 6f;

    [SerializeField] private float lookSpeed = 2f;
    private float lookLimit = 60f; 
    private float gravity = 8f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0f;

    CharacterController characterController;

    public bool canMove = true;
    public bool canRotate = true;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioManager = FindObjectOfType<AudioManager>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        moveDirection = (transform.forward * curSpeedX) + (transform.right * curSpeedY);

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if(canRotate)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookLimit, lookLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (curSpeedX != 0 || curSpeedY != 0)
        {
            audioManager.Play("walk");
        }

        if (curSpeedX == 0 && curSpeedY == 0)
        {
            audioManager.Stop("walk");
        }

    }
}

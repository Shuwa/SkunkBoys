using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    PlayerInputTest playerInputTest;
    CharacterController characterController;
    Animator animator;

    int isWalkingHash;
    int isRunningHash;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    
    
    float rotationFactorPerFrame = 15.0f;
    float runMultiplier = 3.0f;

    void Awake()
    {
        playerInputTest = new PlayerInputTest();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

      //  Callback Context to use OnMovementInput easy
        playerInputTest.Player.Move.started += OnMovementInput;
        playerInputTest.Player.Move.canceled += OnMovementInput;
        playerInputTest.Player.Move.performed += OnMovementInput;
        playerInputTest.Player.Run.started += OnRun;
        playerInputTest.Player.Run.canceled += OnRun;

    }

    void OnRun (InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }
    // Only Rotate the Character on the X and Z axis!!!  
    void handleRotation()
    {
        Vector3 positionToLookAt;
        // change in position our character should point to
        positionToLookAt.x = currentMovement.x;  
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        // current Rotation of character
        Quaternion currentRotation = transform.rotation;
        // 
        

        if (isMovementPressed) 
        {
            // creates new rotation Base ond where the player is currently pressing
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame);


        }

    }

    //argument from Movement Code example :https://www.youtube.com/watch?v=hY54oEsx1Eo
    void OnMovementInput (InputAction.CallbackContext context)
    {
        //Player Controls based on InputManager configuarted Controlls. Basic Movement
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * runMultiplier;
        currentMovement.z = currentMovementInput.y * runMultiplier;
        currentRunMovement.x = currentMovementInput.x /2.0f;
        currentRunMovement.z = currentMovementInput.y /2.0f; 
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void handleAnimation() 
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        

        if (isMovementPressed && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (!isMovementPressed && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }

        if ((isMovementPressed && isRunPressed) && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if ((!isMovementPressed || !isRunPressed) && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

    }


    void handleGravity()

    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -.05f;
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }

        else
        {
            float gravity = -9.8f;
            currentMovement.y += gravity;
            currentRunMovement.y += gravity;

        }
        
    }
    //Update once per frame
    void Update()
    {
        handleRotation();

        handleAnimation();

        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }

        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }
            

        
        
    }
    private void OnEnable()
    {   //Enable character controls action map
        playerInputTest.Player.Enable();
    }
    private void OnDisable()
    {   //Disable character controls action map
        playerInputTest.Player.Disable();
    }
}

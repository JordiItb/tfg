using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    PlayerControls playerControls;
    AnimatorManager animatorManager;
    
    public Vector2 movementInput;
    public Vector2 cameraInput;
    public float isRunning;
    public float isCrouching;

    [HideInInspector] public float cameraInputX;
    [HideInInspector] public float cameraInputY;

    [HideInInspector] public float moveAmount;
    [HideInInspector] public float verticalInput;
    [HideInInspector] public float horizontalInput;

    private void Awake(){
        
        animatorManager = GetComponent<AnimatorManager>();

    }

    private void Start(){

        isRunning = 0;
        isCrouching = 0;

    }

    private void OnEnable(){

        if(playerControls == null){

            playerControls = new PlayerControls();

            //If action is performed -> assign the value to "i" -> assign the "i" value to a script variable.

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>(); //Records movement when WASD is pressed.
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>(); //Records mouse movement.
            playerControls.PlayerMovement.Running.performed += i => isRunning = i.ReadValue<float>(); //Records if player is running.
            playerControls.PlayerMovement.Crouch.performed += i  => isCrouching = i.ReadValue<float>(); //Records if player is crouching.

        }

        playerControls.Enable();

    }

    private void OnDisble(){

        playerControls.Disable();

    }

    public void HandleAllInputs(){

        HandleMovementInput();

    }

    private void HandleMovementInput(){

        /// IMPORTANT /// Crouching has priority over running.

        if(isRunning == 1 && isCrouching == 0f){

            //If running == 1 -> Is running.

            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            animatorManager.UpdateAnimatorValues(0, moveAmount, false);

        }else if(isRunning == 0 && isCrouching == 0f){

            //If running == 0 -> Is walking.

            verticalInput = movementInput.y / 2f;
            horizontalInput = movementInput.x / 2f;
            moveAmount = (Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput))) / 2f;
            animatorManager.UpdateAnimatorValues(0, moveAmount, false);

        }

        if(isRunning == 0f && isCrouching == 1f){

            //If running = 0 and crouching = 1 -> Is crouching.

            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            animatorManager.UpdateAnimatorValues(0, moveAmount, true);
            
        }

        if(isRunning == 1f && isCrouching == 1f){

            //If running = 1 and crouching = 1 -> Is crouching.
            
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            animatorManager.UpdateAnimatorValues(0, moveAmount, true);

        }

        //Mouse inputs for camera

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

    }
}

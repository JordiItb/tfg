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

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake(){
        
        animatorManager = GetComponent<AnimatorManager>();

    }

    private void Start(){

        isRunning = 0;

    }

    private void OnEnable(){

        if(playerControls == null){

            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>(); //Records movement when WASD is pressed.
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>(); //Records mouse movement.
            playerControls.PlayerMovement.Running.performed += i => isRunning = i.ReadValue<float>(); //Records if player is running.

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

        if(isRunning == 1){

            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            animatorManager.UpdateAnimatorValues(0, moveAmount);

        }else{

            verticalInput = movementInput.y / 2f;
            horizontalInput = movementInput.x / 2f;
            moveAmount = (Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput))) / 2f;
            animatorManager.UpdateAnimatorValues(0, moveAmount);

        }

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        

    }
}

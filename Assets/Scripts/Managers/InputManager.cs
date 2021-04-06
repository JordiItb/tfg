﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    PlayerControls playerControls;
    public PhotoreceptionSystem photoreceptionSystem;
    AnimatorManager animatorManager;
    
    public Vector2 movementInput;
    public Vector2 cameraInput;
    public float isRunning;
    public float isCrouching;
    public float isConcentrating;
    public float isTeleporting;
    public float isGrabbing;
    public float isWaving;

    [HideInInspector] public float cameraInputX;
    [HideInInspector] public float cameraInputY;

    [HideInInspector] public float moveAmount;
    [HideInInspector] public float verticalInput;
    [HideInInspector] public float horizontalInput;

    private void Awake(){
        
        animatorManager = GetComponent<AnimatorManager>();
        photoreceptionSystem = GameObject.FindObjectOfType<PhotoreceptionSystem>().GetComponent<PhotoreceptionSystem>();

    }

    private void Start(){

        isRunning = 0;
        isCrouching = 0;
        isConcentrating = 0;

    }

    private void OnEnable(){

        if(playerControls == null){

            playerControls = new PlayerControls();

            //If action is performed -> assign the value to "i" -> assign the "i" value to a script variable.

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>(); //Records movement when WASD is pressed.
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>(); //Records mouse movement.
            playerControls.PlayerMovement.Running.performed += i => isRunning = i.ReadValue<float>(); //Records if player is running.
            playerControls.PlayerMovement.Crouch.performed += i  => isCrouching = i.ReadValue<float>(); //Records if player is crouching.
            playerControls.PlayerMovement.Concentrate.performed += i => isConcentrating = i.ReadValue<float>(); //Records if player is concentrating.
            playerControls.PlayerMovement.Grab.performed += i => isGrabbing = i.ReadValue<float>(); //Records if player is grabbing.
            playerControls.PlayerMovement.Teleport.performed += i => isTeleporting = i.ReadValue<float>(); //Records if player is teleporting.
            playerControls.PlayerMovement.Wave.performed += i => isWaving = i.ReadValue<float>(); //Records if player is waving.


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

        if(isRunning == 1 && isCrouching == 0f && isConcentrating == 0f){

            //If running == 1 -> Is running.

            MovePlayer(true, 1f, false, false);

        }else if(isRunning == 0 && isCrouching == 0f && isConcentrating == 0f){

            //If running == 0 -> Is walking.

            MovePlayer(true, 2f, false, false);

        }

        if(isRunning == 0f && isCrouching == 1f && isConcentrating == 0f){

            //If running = 0 and crouching = 1 -> Is crouching.

            MovePlayer(true, 1f, true, false);
            
        }

        if(isRunning == 1f && isCrouching == 1f && isConcentrating == 0f){

            //If running = 1 and crouching = 1 -> Is crouching.

            MovePlayer(true, 1f, true, false);

        }
        if(photoreceptionSystem.lightValue <= 0.03f){
            if(isConcentrating == 1f){
                MovePlayer(false, 1f, false, true);
            }
        }else{
            isConcentrating = 0f;
        }

        //Mouse inputs for camera

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

    }

    private void MovePlayer(bool canMove, float movementDivider, bool crouch, bool concentrating){
        
        if(canMove){
            verticalInput = movementInput.y / movementDivider;
            horizontalInput = movementInput.x / movementDivider;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)) / movementDivider;
        }else{
            verticalInput = 1f;
            horizontalInput = 0f;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)) / movementDivider;
        }

        animatorManager.UpdateAnimatorValues(0, moveAmount, crouch, concentrating);

    }
}
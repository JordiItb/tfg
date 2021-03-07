using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;

    Rigidbody rb;

    public float walkingSpeed;
    public float runningSpeed;
    public float rotationSpeed;

    private void Awake(){

        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;

    }

    public void HandleAllMovement(){

        HandleMovement();
        HandleRotation();

    }

    private void HandleMovement(){

        #region Player Movement Calculation.
        moveDirection = cameraObject.forward * inputManager.verticalInput; //Moves player the direction the camera is facing.
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput; //Moves player left/right based on the camera direction.
        moveDirection.Normalize(); //Changes vector length to 1 (0 if it's too small).
        moveDirection.y = 0;

        if(inputManager.isRunning == 1f){
            moveDirection = moveDirection * runningSpeed;
        }
        else{
            moveDirection = moveDirection * walkingSpeed;
        }
        

        Vector3 movementVelocity = moveDirection;
        #endregion
        rb.velocity = movementVelocity; //Moves player according to the calculation above.

    }

    private void HandleRotation(){

        #region Player Rotation Calculation.
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput; //Rotates the player the direction the camera is facing.
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput; //Rotates player left/right based on the camera direction.
        targetDirection.Normalize(); //Changes vector length to 1 (0 if it's too small).
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero){
            targetDirection = transform.forward; //Keeps rotation when player stops moving instad of snapping back to origin.
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection); //Looks towards our target direction to rotate to what we are looking.
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //Rotates between two points (actual player rotation -> target rotation).
        #endregion
        transform.rotation = playerRotation; //Rotates player according to the calculation above.

    }
}

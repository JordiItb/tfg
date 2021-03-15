using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    InputManager inputManager;

    [SerializeField] Vector3 moveDirection;
    Transform cameraObject;

    Rigidbody rb;
    
    [Header("Movement Speed")]
    [Range(0, 5)] public float walkingSpeed;
    [Range(5, 15)] public float runningSpeed;
    [Range(0, 1)] public float crouchingSpeed;
    [Range(0, 40)] public float rotationSpeed;

    [Header("Ground Check")]
    public Transform sphereCheck;
    [Range(0, 1)] public float radiusDistace;
    public LayerMask groundMask;
    [SerializeField] private bool isGrounded;

    [Header("Slope And Stair Movement")]
    [Range(0,10)] public float slopeRadius;
    public float downSlopeForce;
    public Transform stepUp;
    public Transform stepLow;
    public float stepSmooth;
    [Range(0,1)] public float upperLength;
    [Range(0,1)] public float lowerLength;

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

        isGrounded = Physics.CheckSphere(sphereCheck.position, radiusDistace, groundMask);

        if(!isGrounded && !OnSlope()){
            //Normal fall.
            rb.velocity = rb.velocity = new Vector3(moveDirection.x , Vector3.down.y * 9.81f, moveDirection.z);
        }else if(!isGrounded && OnSlope()){
            //Slope fall (augmented fall in order for player to not "bounce" while falling).
            rb.velocity = rb.velocity = new Vector3(moveDirection.x , Vector3.down.y * 9.81f * downSlopeForce, moveDirection.z);
        }
        else{
            #region Player Movement Calculation.
                moveDirection = cameraObject.forward * inputManager.verticalInput; //Moves player the direction the camera is facing.
                moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput; //Moves player left/right based on the camera direction.
                moveDirection.Normalize(); //Changes vector length to 1 (0 if it's too small).
                moveDirection.y = 0;

                if(inputManager.isRunning == 1f && inputManager.isCrouching == 0f){
                    moveDirection = moveDirection * runningSpeed; //Running.
                }
                if(inputManager.isRunning == 0f && inputManager.isCrouching == 0f){
                    moveDirection = moveDirection * walkingSpeed; //Walking.
                }
                if(inputManager.isCrouching == 1f && inputManager.isRunning == 0f || inputManager.isRunning == 1f){
                    moveDirection = moveDirection * crouchingSpeed; //Crouching.
                }
                
                Vector3 movementVelocity = moveDirection;
            #endregion
            rb.velocity = movementVelocity; //Moves player according to the calculation above.
        }

        #region Stair Movement Handler.
            if(!OnSlope()){
                RaycastHit hitLower;
                //If colliding with anything.
                if(Physics.Raycast(stepLow.position, transform.TransformDirection(Vector3.forward), out hitLower, lowerLength)){
                    RaycastHit hitUpper;
                    //If the object we collide with is not too tall.
                    if(!Physics.Raycast(stepUp.position, transform.TransformDirection(Vector3.forward), out hitUpper, upperLength)){
                        rb.position += new Vector3(0f, stepSmooth * Time.deltaTime, 0f);
                    }
                }

                //Above code will not detect if player is colliding a stair through an angle (walking in diagonal).
                //Below code needed to fix that.

                RaycastHit hitLower45;
                //If colliding with anything at +45.
                if(Physics.Raycast(stepLow.position, transform.TransformDirection(1.5f, 0f, 1f), out hitLower45, lowerLength)){
                    RaycastHit hitUpper45;
                    //If the object we collide with is not too tall.
                    if(!Physics.Raycast(stepUp.position, transform.TransformDirection(1.5f, 0f, 1f), out hitUpper45, upperLength)){
                        rb.position += new Vector3(0f, stepSmooth * Time.deltaTime, 0f);
                    }
                }

                RaycastHit hitLowerMinus45;
                //If colliding with anything at -45.
                if(Physics.Raycast(stepLow.position, transform.TransformDirection(-1.5f, 0f, 1f), out hitLowerMinus45, lowerLength)){
                    RaycastHit hitUpperMinus45;
                    //If the object we collide with is not too tall.
                    if(!Physics.Raycast(stepUp.position, transform.TransformDirection(-1.5f, 0f, 1f), out hitUpperMinus45, upperLength)){
                        rb.position += new Vector3(0f, stepSmooth * Time.deltaTime, 0f);
                    }
                }
            }
        #endregion

    }

    //Slope check method. Returns true if the normal of the raycast is different from 1 (surface is tilted).
    private bool OnSlope(){

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, GetComponent<CapsuleCollider>().height / 2 * slopeRadius)){
            if(hit.normal != Vector3.up){
                return true;
            }
        }
        return false;

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

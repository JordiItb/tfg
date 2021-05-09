using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    InputManager inputManager;
    PlayerHabilities playerHabilities;

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

    [Header("Colliders")]
    public CapsuleCollider normalCollider;
    public CapsuleCollider crouchCollider;

    bool crouch;

    private void Awake(){

        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        playerHabilities = GetComponent<PlayerHabilities>();
        cameraObject = Camera.main.transform;
        normalCollider.enabled = true;
        crouchCollider.enabled = false;
        crouch = false;

    }

    public void HandleAllMovement(){

        HandleMovement();
        HandleRotation();

    }

    private void HandleMovement(){
        //If player is tping, movement is disabled.
        if(!playerHabilities.tping){

            isGrounded = Physics.CheckSphere(sphereCheck.position, radiusDistace, groundMask);

            if(!isGrounded && !OnSlope()){
                //Normal fall.
                rb.velocity = new Vector3(moveDirection.x , Vector3.down.y * 9.81f, moveDirection.z);
            }else if(!isGrounded && OnSlope()){
                //Slope fall (augmented fall in order for player to not "bounce" while falling).
                rb.velocity = new Vector3(moveDirection.x , Vector3.down.y * 9.81f * downSlopeForce, moveDirection.z);
            }else if(inputManager.isConcentrating == 1){
                rb.velocity = Vector3.zero;
            }
            else{
                #region Player Movement Calculation.
                    moveDirection = cameraObject.forward * inputManager.verticalInput; //Moves player the direction the camera is facing.
                    moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput; //Moves player left/right based on the camera direction.
                    moveDirection.Normalize(); //Changes vector length to 1 (0 if it's too small).
                    moveDirection.y = 0;

                    if(inputManager.isRunning == 1f && inputManager.isCrouching == 0f && inputManager.isConcentrating == 0f){
                        moveDirection = moveDirection * runningSpeed; //Running.
                    }
                    if(inputManager.isRunning == 0f && inputManager.isCrouching == 0f  && inputManager.isConcentrating == 0f){
                        moveDirection = moveDirection * walkingSpeed; //Walking.
                    }
                    if(inputManager.isCrouching == 1f && inputManager.isRunning == 0f  && inputManager.isConcentrating == 0f || inputManager.isRunning == 1f){
                        moveDirection = moveDirection * crouchingSpeed; //Crouching.
                    }
                    
                    //Player colliders, changes according if player is crouching or not.
                    if(inputManager.isCrouching == 1f){
                        normalCollider.enabled = false;
                        crouchCollider.enabled = true;
                    }else{
                        normalCollider.enabled = true;
                        crouchCollider.enabled = false;
                    }
                    #region Detection of upper objects when crouching.
                    if(inputManager.isCrouching == 1f || crouch){

                        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y + transform.localScale.y, transform.position.z), Vector3.up / 2f, Color.white);

                        if(Physics.Raycast(new Vector3(transform.position.x,transform.position.y + transform.localScale.y, transform.position.z), Vector3.up, 0.5f)){
                            
                            inputManager.isCrouching = 1f;
                            crouch = true;

                        }else if(crouch){
                            inputManager.isCrouching = 0f;
                            crouch = false;
                        }
                    }
                    #endregion
                    
                    Vector3 movementVelocity = moveDirection;
                #endregion
                rb.velocity = movementVelocity; //Moves player according to the calculation above.
            }

        }

    }
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

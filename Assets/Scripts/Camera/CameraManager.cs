using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    [Header("Positions")]
    public Transform targetTransform; //The object the camera will follow.
    public Transform cameraPivot; //The object the camera uses to pivot.
    public Transform cameraTransform;
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    public LayerMask collisionLayers; //The layers the camera will collide with.
    private Vector3 cameraVectorPosition;
    [Header("Off sets")]
    [Range(0, 1)] public float cameraCollisionOffSet; //How much the camera will jump off of objects its colliding with.
    [Range(0, 1)] public float minimumCollisionOffSet;
    [Range(0, 1)] public float cameraCollisionRadius;
    [Header("Camera speed")]
    [Range(0, 1)] public float cameraFollowSpeed;
    [Range(0, 1)] public float cameraLookSpeed;
    [Range(0, 1)] public float cameraPivotSpeed;
    private float lookAngle; //Camera looking up and down.
    private float pivotAngle; //Camera looking left and right.
    [Header("Angles")]
    public float minimumPivotAngle;
    public float maximumPivotAngle;


    private void Awake(){

        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;

    }

    public void HandleAllCameraMovement(){

        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();

    }

    private void FollowTarget(){

        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;

    }

    private void RotateCamera(){

        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;

    }

    private void HandleCameraCollisions(){

        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if(Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers)){

            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffSet);

        }

        if(Mathf.Abs(targetPosition) < minimumCollisionOffSet){

            targetPosition = targetPosition - minimumCollisionOffSet;
            
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;

    }
}

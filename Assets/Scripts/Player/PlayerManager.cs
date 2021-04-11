using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;
    PlayerHabilities playerHabilities;

    private void Awake(){
    
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerHabilities = GetComponent<PlayerHabilities>();

    }

    private void Update(){

        inputManager.HandleAllInputs();
        playerHabilities.HandleAllHabilities();

    }

    private void FixedUpdate(){

        playerLocomotion.HandleAllMovement();

    }

    private void LateUpdate(){

        cameraManager.HandleAllCameraMovement();

    }
}

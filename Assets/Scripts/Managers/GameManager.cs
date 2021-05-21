using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    const float fpsMeasurePeriod = 0.1f;
    private int m_FpsAccumulator = 0;
    private float m_FpsNextPeriod = 0;
    private int m_CurrentFps;

    PhotoreceptionSystem photoreceptionSystem;
    [Header("Debug")]
    public Text lightText;
    public Text fpsText;
    [Header("Helper Panel")]
    public Text helperText;
    public GameObject helperPanel;
    [Header("Interact Panel")]
    public GameObject interactPanel;
    public Text interactText;
    public string intreactKey;

    bool gamepad;
    bool keyboard;

    PlayerManager playerManager;
    InputManager inputManager;
    Volume volume;
    Vignette vignette;
    
    void Awake(){

        photoreceptionSystem = FindObjectOfType<PhotoreceptionSystem>();
        playerManager = FindObjectOfType<PlayerManager>();
        inputManager = FindObjectOfType<InputManager>();
        volume = FindObjectOfType<Volume>();

    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        volume.profile.TryGet(out vignette);
    }

    void Update(){
        
    #if UNITY_EDITOR

        lightText.text = "Light Value: " + photoreceptionSystem.lightValue;
        m_FpsAccumulator++;
        if (Time.realtimeSinceStartup > m_FpsNextPeriod){
            m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
            m_FpsAccumulator = 0;
            m_FpsNextPeriod += fpsMeasurePeriod;
            fpsText.text = "FPS: " + m_CurrentFps;
        }

        if(inputManager.scene1 == 1f){
            SceneManager.LoadScene(0);
        }
        if(inputManager.scene2 == 1f){
            SceneManager.LoadScene(1);
        }
    
    #endif

        vignette.intensity.value = (-playerManager.health / 100f) + 1f;

        if(playerManager.health <= 0f){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    if(Gamepad.current.IsActuated() && !gamepad){
        intreactKey =  "B";
        keyboard = false;
        gamepad = true;
    }else if(Keyboard.current.IsActuated() && !keyboard){
        intreactKey =  "F";
        gamepad = false;
        keyboard = true;
    }

    }

    public void setHelperText(string text){
        
        SetText(helperPanel, helperText, text);

    }

    public void Interact(GameObject obj){
        
        if(obj.GetComponent<Key>()){
            
            SetInteracText("[" + intreactKey + "] To Pick Up Key");
            if(inputManager.isPicking == 1f){
                obj.GetComponent<Key>().PickUp();
            }

        }else if(obj.GetComponent<LockedDoor>()){

            SetInteracText("["+ intreactKey + "] To Open Door");
            if(inputManager.isPicking == 1f){
                obj.GetComponent<LockedDoor>().OpenDoor();
            }

        }

    }

    public void HideInteractText(){

        interactPanel.SetActive(false);

    }

    void SetInteracText(string text){

        SetText(interactPanel, interactText, text);

    }

    void SetText(GameObject panel, Text text, string inputText){
        
        panel.SetActive(false);
        panel.SetActive(true);
        text.text = inputText;

    }

}

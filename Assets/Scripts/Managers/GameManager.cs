using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    const float fpsMeasurePeriod = 0.1f;
    private int m_FpsAccumulator = 0;
    private float m_FpsNextPeriod = 0;
    private int m_CurrentFps;

    PhotoreceptionSystem photoreceptionSystem;
    public Text lightText;
    public Text fpsText;

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

        lightText.text = "Light Value: " + photoreceptionSystem.lightValue;
        m_FpsAccumulator++;
        if (Time.realtimeSinceStartup > m_FpsNextPeriod){
            m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
            m_FpsAccumulator = 0;
            m_FpsNextPeriod += fpsMeasurePeriod;
            fpsText.text = "FPS: " + m_CurrentFps;
        }

        vignette.intensity.value = (-playerManager.health / 100f) + 1f;

        if(playerManager.health <= 0f){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(inputManager.scene1 == 1f){
            SceneManager.LoadScene(0);
        }
        if(inputManager.scene2 == 1f){
            SceneManager.LoadScene(1);
        }

    }

}

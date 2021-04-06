using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    const float fpsMeasurePeriod = 0.1f;
    private int m_FpsAccumulator = 0;
    private float m_FpsNextPeriod = 0;
    private int m_CurrentFps;

    PhotoreceptionSystem photoreceptionSystem;
    public Text lightText;
    public Text fpsText;
    
    void Awake(){

        photoreceptionSystem = GameObject.FindObjectOfType<PhotoreceptionSystem>().GetComponent<PhotoreceptionSystem>();

    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

    }

}

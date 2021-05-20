﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialLightManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){

        if(collision.collider.CompareTag("Interactuable") && GetComponent<Light>().enabled == true){

            GetComponent<ParticleSystem>().Play(true);

            GetComponent<Light>().enabled = false;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificalLightManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){

        if(collision.collider.CompareTag("Interactuable")){
            Destroy(this.gameObject);
        }

    }

}

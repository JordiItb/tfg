using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialLightManager : MonoBehaviour
{

    void OnCollisionEnter(Collision collision){

        if(collision.collider.CompareTag("Interactuable") || collision.collider.GetComponent<EnemyAI>() && GetComponent<Light>().enabled == true){

            GetComponent<ParticleSystem>().Play(true);

            GetComponent<Light>().enabled = false;
        }

    }

}

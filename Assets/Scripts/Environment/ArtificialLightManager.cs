using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialLightManager : MonoBehaviour
{

    public AudioSource breakSound;

    void OnCollisionEnter(Collision collision){

        if(collision.collider.CompareTag("Interactuable") || collision.collider.GetComponent<EnemyAI>()){

            if(GetComponent<Light>().enabled == true){
                GetComponent<ParticleSystem>().Play(true);

                breakSound.Play();

                GetComponent<Light>().enabled = false;
            }

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreObject : MonoBehaviour
{
    [TextArea]
    public string loreText;
    GameManager gameManager;

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }

    public string GetLore(){

        return loreText;

    }

    void OnTriggerStay(Collider collider){

        if(collider.gameObject.tag == "Player"){
            gameManager.Interact(this.gameObject);
        }

    }

    void OnTriggerExit(Collider collider){

        gameManager.HideInteractText();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public string text;
    private GameManager gm;
    public bool picked;

    void Start(){

        gm = FindObjectOfType<GameManager>();
        picked = false;

    }

    void OnTriggerStay(Collider collider){

        if(collider.gameObject.tag == "Player"){

            gm.Interact(this.gameObject);

        }

    }

    void OnTriggerExit(Collider collider){

        if(collider.gameObject.tag == "Player"){
            gm.HideInteractText();
        }

    }

    public void PickUp(){

        gm.setHelperText(text);

        picked = true;

        gm.HideInteractText();

        this.gameObject.SetActive(false);

    }

}

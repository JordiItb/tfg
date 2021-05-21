using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

    GameManager gameManager;

    public bool locked;
    public Key key;
    public string text;
    public Collider interactCollider;

    void Start(){

        locked = true;
        text = "It won't open. I think i need a key.";
        gameManager = FindObjectOfType<GameManager>();

    }


    public void SetLocked(bool locked){

        this.locked = locked;

    }

    public bool GetLocked(){
        return locked;
    }

    public string GetText(){

        if(!locked){
            return "You've opened the door.";
        }

        return text;

    }

    public void OpenDoor(){

        if(key != null){
            if(key.picked && key.door == this.gameObject){
                SetLocked(false);
                gameManager.HideInteractText();
                interactCollider.enabled = false;
            }else{
                SetLocked(true);
            }
        }
        gameManager.setHelperText(GetText());

    }

    void OnTriggerStay(Collider collider){

        if(collider.gameObject.tag == "Player"){
            gameManager.Interact(this.gameObject);
        }

    }

    void OnTriggerExit(Collider collider){

        if(collider.gameObject.tag == "Player"){
            gameManager.HideInteractText();
        }

    }

}

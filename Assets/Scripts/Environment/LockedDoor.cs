using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool locked;
    public string text;

    void Start(){

        locked = true;
        text = "It won't open. I think i need a key.";

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

}

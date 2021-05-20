using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public string text;
    private GameManager gm;

    void Start(){

        gm = FindObjectOfType<GameManager>();

    }

    void OnTriggerEnter(Collider collider){

        if(collider.gameObject.tag == "Player"){

            door.GetComponent<LockedDoor>().SetLocked(false);

            gm.setHelperText(text);

            Destroy(this.gameObject);

        }

    }

}

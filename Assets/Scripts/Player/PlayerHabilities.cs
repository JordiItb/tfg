using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilities : MonoBehaviour
{
    InputManager inputManager;
    PhotoreceptionSystem photoreception;
    Material defMat;
    
    [Header("Ray Settings")]
    public float maxRayLength;
    [SerializeField] bool hovered;
    [SerializeField] GameObject hitObject;
    [Header("Object")]
    public Material highlighted;
    public GameObject pointer;
    public Transform grabPos;
    [Range(0, 1)]public float objectFollowSpeed;
    private Vector3 objectFollowVelocity = Vector3.zero;

    

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        photoreception = GameObject.FindObjectOfType<PhotoreceptionSystem>().GetComponent<PhotoreceptionSystem>();
        hovered = false;
    }

    public void HandleAllHabilities(){

        Grabbing();

    }

    public void Grabbing(){

        if(inputManager.isConcentrating == 1f){

            pointer.SetActive(true);
            
            RaycastHit hit;

            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * maxRayLength, Color.yellow);

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, maxRayLength)){
                
                if(hit.collider.CompareTag("Interactuable")){
                            
                    hitObject = hit.collider.gameObject;

                    if(!hovered){
                        defMat = hitObject.GetComponent<MeshRenderer>().material;
                        hovered = true;
                    }

                    hitObject.GetComponent<MeshRenderer>().material = highlighted;

                    if(inputManager.isGrabbing == 1f){

                        if(hitObject.transform.position != grabPos.position){
                            hitObject.transform.position = Vector3.SmoothDamp(hitObject.transform.position, grabPos.position, ref objectFollowVelocity, objectFollowSpeed);
                        }else hitObject.transform.position = grabPos.position;                    
                        
                        hitObject.GetComponent<Rigidbody>().useGravity = false;

                    }else hitObject.GetComponent<Rigidbody>().useGravity = true;
                    

                }else{

                    hovered = false;

                    if(hitObject != null){
                        hitObject.GetComponent<MeshRenderer>().material = defMat;
                        hitObject.GetComponent<Rigidbody>().useGravity = true;
                    }
                    
                }

            }else{

                if(hitObject != null){
                    hitObject.GetComponent<MeshRenderer>().material = defMat;
                    hitObject.GetComponent<Rigidbody>().useGravity = true;
                }

            }
            
        }else{

            pointer.SetActive(false);
            if(hitObject != null) hitObject.GetComponent<MeshRenderer>().material = defMat;
                

        }

    }
}

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
    private float grabZoom;
    private bool grabbing;

    

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        photoreception = GameObject.FindObjectOfType<PhotoreceptionSystem>().GetComponent<PhotoreceptionSystem>();
        hovered = false;
        grabZoom = grabPos.position.z;
    }

    public void HandleAllHabilities(){

        Grabbing();

    }

    public void Grabbing(){

        //Set grabbing zoom.

        grabZoom += -inputManager.mouseWheel * 0.001f;
        grabZoom = Mathf.Clamp(grabZoom, 1.7f, 4f);
        
        //Grabbing object.

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

                        grabbing = true;

                    }else if(!grabbing) hitObject.GetComponent<Rigidbody>().useGravity = true;
                    

                }else{

                    if(inputManager.isGrabbing == 0f && !grabbing){

                        if(hitObject != null){
                            hitObject.GetComponent<MeshRenderer>().material = defMat;
                            hitObject.GetComponent<Rigidbody>().useGravity = true;
                        }

                    }
                    
                }

            }else{

                if(hitObject != null && inputManager.isGrabbing == 0f){
                    hitObject.GetComponent<MeshRenderer>().material = defMat;
                    hitObject.GetComponent<Rigidbody>().useGravity = true;
                }

            }
            
        }else{
            
            grabbing = false;
            hovered = false;
            pointer.SetActive(false);

            if(hitObject != null){

               hitObject.GetComponent<Rigidbody>().useGravity = true; 
               hitObject.GetComponent<MeshRenderer>().material = defMat;

            }
                

        }

        if(grabbing){
            moveObject();
        }

    }

    void moveObject(){

        hitObject.transform.position = Vector3.Lerp(hitObject.transform.position, grabPos.position, objectFollowSpeed);
                        
        hitObject.GetComponent<Rigidbody>().useGravity = false;

        if(inputManager.isWaving == 1f){

            hitObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 10f, ForceMode.Impulse);
            grabbing = false;

        }

    }
}

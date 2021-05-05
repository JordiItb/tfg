using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilities : MonoBehaviour
{
    InputManager inputManager;
    PhotoreceptionSystem photoreception;
    Material defMat;
    RaycastHit hit;
    RaycastHit height;
    
    [Header("Ray Settings")]
    public float maxRayLength;
    bool hovered;
    GameObject hitObject;
    [Header("Object")]
    public Material highlighted;
    public GameObject pointer;
    public Transform grabPos;
    [Range(0, 1)]public float objectFollowSpeed;
    [Range(0, 0.5f)] public float playerTeleportSpeed;
    private float grabZoom;
    private bool grabbing;
    private float waveCooldown;
    [Header("Wave Settings")]
    public float waveSeconds;
    public float waveForce;
    [Header("Teleport Settings")]
    public GameObject teleport;
    public float teleportSeconds;
    public bool tping;
    private float teleportCooldown;
    private Vector3 tpPos;
    [Header("Particles")]
    public ParticleSystem[] particles;
    
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        photoreception = GameObject.FindObjectOfType<PhotoreceptionSystem>().GetComponent<PhotoreceptionSystem>();
        hovered = false;
        grabZoom = grabPos.position.z;
        waveCooldown = 0f;
    }

    public void HandleAllHabilities(){

        Concentrating();

    }

    public void Concentrating(){

        if(inputManager.isConcentrating == 1f){

            pointer.SetActive(true);
            
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * maxRayLength, Color.yellow);

            //Checks if the raycast is colliding with anything withing the given range.
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, maxRayLength)){

                //Checks if the object is interactuable.
                if(hit.collider.CompareTag("Interactuable")){

                    #region Highlight object.
                    hitObject = hit.collider.gameObject;
                    if(hovered){
                        hitObject.GetComponent<MeshRenderer>().material = highlighted;
                    }else{
                        defMat = hitObject.GetComponent<MeshRenderer>().material;
                        hovered = true;
                    }
                    #endregion

                    PulseWave(hitObject);

                //If the object is not interactuable, returns the last interactuable object to the default state.
                }else{

                    Teleport(hit);

                    hovered = false;

                    if(hitObject != null && !grabbing){
                        hitObject.GetComponent<MeshRenderer>().material = defMat;
                    }
                    
                }

            //If the raycast is not colliding with anything, returns the last interactuable object to its default state.
            }else{

                particles[2].Stop();

                if(hitObject != null && !grabbing){
                    hitObject.GetComponent<MeshRenderer>().material = defMat;
                    hitObject.GetComponent<Rigidbody>().useGravity = true;
                    hitObject = null;
                }

            }

            Grabbing(hitObject);

        //If player is not concentrating, returns the last interactuable object to its default state.
        }else{

            particles[2].Stop();
                        
            grabbing = false;
            hovered = false;
            pointer.SetActive(false);

            if(hitObject != null){

               hitObject.GetComponent<Rigidbody>().useGravity = true; 
               hitObject.GetComponent<MeshRenderer>().material = defMat;
               hitObject = null;

            }

            //if(photoreception.lightValue >= 0.02f){
              //  Teleport(hit);
            //}

            Teleport(hit);
                
        }

    }

    public void Grabbing(GameObject grabObj){

        //Grabbing object.
        
        if(inputManager.isGrabbing == 1f && grabObj != null){

            grabbing = true;

        }

        if(grabbing) moveObject(grabObj);

    }

    void moveObject(GameObject grabObj){

        //Set grabbing zoom.

        grabZoom += -inputManager.mouseWheel * 0.001f;
        grabZoom = Mathf.Clamp(grabZoom, 1.7f, 4f);

        //Move the object

        grabObj.transform.position = Vector3.Lerp(grabObj.transform.position, grabPos.position, objectFollowSpeed);
                        
        grabObj.GetComponent<Rigidbody>().useGravity = false;

        PulseWave(grabObj);

    }

    public void PulseWave(GameObject obj){
        
        if(inputManager.isConcentrating == 1f && inputManager.isWaving == 1f && Time.time >= waveCooldown){

            obj.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * waveForce, ForceMode.Impulse);
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<MeshRenderer>().material = defMat;
            grabbing = false;
            hovered = false;
            hitObject = null;

            waveCooldown = Time.time + waveSeconds;

        }

    }

    public void Teleport(RaycastHit hit){

        //Debug.Log(hit.normal);

        if(hit.normal.y > 0f){
            
            if(inputManager.isConcentrating == 1f) particles[2].Play();

            teleport.transform.position = hit.point;

            TeleportPlayer(hit.point);

        }else if(hit.normal.y < 0f){

            Debug.DrawRay(hit.point, Vector3.down * 20f, Color.white);

            if(!tping){
                
                if(Physics.Raycast(hit.point - Vector3.down, Vector3.down, out height, Mathf.Infinity)){

                    if(inputManager.isConcentrating == 1f) particles[2].Play();

                }

                teleport.transform.position = height.point;

            }

            TeleportPlayer(height.point);

        }
        else{
            particles[2].Stop();
        }

    }

    void TeleportPlayer(Vector3 point){

        if(inputManager.isTeleporting == 1f && Time.time >= teleportCooldown && tping == false && photoreception.lightValue <= 0.023f){

                GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                particles[1].Play();
                particles[0].Play();

                tpPos = point;

                tping = true;

                teleportCooldown = Time.time + teleportSeconds;

            }
            
            if(tping){

                transform.position = Vector3.Lerp(transform.position, tpPos, playerTeleportSpeed);

                if(Mathf.Approximately(transform.position.x, tpPos.x) && Mathf.Approximately(transform.position.z, tpPos.z)){
                    particles[0].Stop();
                    particles[1].Play();
                    GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                    tping = false;
                }

            }
        
    }

}

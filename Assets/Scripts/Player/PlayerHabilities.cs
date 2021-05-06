﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHabilities : MonoBehaviour
{
    InputManager inputManager;
    PhotoreceptionSystem photoreception;
    Material defMat;
    RaycastHit hit;
    RaycastHit height;
    RaycastHit wall;
    public Rigidbody rb;
    
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
    bool TPready;
    [Header("Particles")]
    public ParticleSystem[] particles;
    
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        photoreception = GameObject.FindObjectOfType<PhotoreceptionSystem>().GetComponent<PhotoreceptionSystem>();
        hovered = false;
        grabZoom = grabPos.position.z;
        waveCooldown = 0f;
        TPready = true;
    }

    public void HandleAllHabilities(){

        Concentrating();

    }

    public void Concentrating(){

        if(inputManager.isConcentrating == 1f){

            pointer.SetActive(true);
            
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * maxRayLength, Color.yellow);

            //If player is not tping then the raycast can be done (this prevents from the raycast point to change when tping, causing player to stop tping to where they wanted).
            if(!tping){
                //Checks if the raycast is colliding with anything withing the given range.
                if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, maxRayLength)){
                    //Checks if the player is already grabbing something, in order to prevent multiple grabbing.
                    if(!grabbing){
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
                    }else{

                        Teleport(hit);

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
            }else{
                Teleport(hit);
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

        grabObj.transform.Rotate(0, 0, 50 * Time.deltaTime);
        
                        
        grabObj.GetComponent<Rigidbody>().useGravity = false;

        PulseWave(grabObj);

    }

    public void PulseWave(GameObject obj){

        //If the player perfoms the action of pulse waving when concentrating, adds a force to the selected object.        
        if(inputManager.isConcentrating == 1f && inputManager.isWaving == 1f && Time.time >= waveCooldown){

            obj.GetComponent<Rigidbody>().AddForce((Camera.main.transform.forward + Vector3.up / 2f) * waveForce, ForceMode.Impulse);
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<MeshRenderer>().material = defMat;
            grabbing = false;
            hovered = false;
            hitObject = null;

            waveCooldown = Time.time + waveSeconds;

        }

    }

    public void Teleport(RaycastHit hit){

        if(Time.time >= teleportCooldown && !TPready){
            particles[3].Play();
        }
        if(particles[3].isPlaying){
            TPready = true;
        }

        //If the normal of the raycast is greater than 0, means that the player wants to teleport to an area from above/the same level.
        if(hit.normal.y > 0f){
            
            if(inputManager.isConcentrating == 1f) particles[2].Play();

            teleport.transform.position = hit.point;

            TeleportPlayer(hit.point);

        //If the normal of the raycast is smaller than 0, means that the player wants to teleport to an area from below.
        }else if(hit.normal.y < 0f){

            Debug.DrawRay(hit.point, Vector3.down * maxRayLength, Color.white);

            if(!tping){
                //Shoots a raycast from the intersection point of the original raycast in order to find the point where the player wants to be teleported to.
                if(Physics.Raycast(hit.point - Vector3.down, Vector3.down, out height, maxRayLength)){

                    if(inputManager.isConcentrating == 1f) particles[2].Play();

                }

                teleport.transform.position = height.point;

            }

            TeleportPlayer(height.point);

        //If the normal of the raycast is equal to 0, means that the player is pointing to a wall, so a raycast pointing down will be the point the player will be teleported to.
        }else if(hit.normal.y == 0f){

            Debug.DrawRay(hit.point + hit.normal, Vector3.down * maxRayLength, Color.white);
            if(!tping){
                //Shoots a raycast from the wall to find the point where the player wants to be teleported to, with an offset so when the player teleports, doesn't teleport into the wall.
                if(Physics.Raycast(hit.point + hit.normal, Vector3.down, out wall, maxRayLength)){

                    if(wall.normal.y > 0f){
                        if(inputManager.isConcentrating == 1f) particles[2].Play();
                        teleport.transform.position = wall.point;
                    }
                    
                }

            }

            TeleportPlayer(wall.point + hit.normal);

        }
        else{
            particles[2].Stop();
        }

    }

    void TeleportPlayer(Vector3 point){
        
        //If the player performs the action of teleportation, the ability is not on cooldown and the light value is lower than the allowed, the player will be teleported to the desired location.
        if(inputManager.isTeleporting == 1f && Time.time >= teleportCooldown && tping == false && photoreception.lightValue <= inputManager.lightLevel){

            rb.useGravity = false;
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            particles[1].Play();
            particles[0].Play();

            tpPos = point;

            tping = true;
            TPready = false;

        }
            
        if(tping){

            transform.position = Vector3.Lerp(transform.position, tpPos, playerTeleportSpeed);
            //If the position of the player is approximate to the one of the teleport location, then the teleport action will end and the player will be able to move again.
            if(Mathf.Approximately(transform.position.x, tpPos.x) && Mathf.Approximately(transform.position.z, tpPos.z)){
                rb.useGravity = true;
                particles[0].Stop();
                particles[1].Play();
                GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                teleportCooldown = Time.time + teleportSeconds;
                TPready = false;


                tping = false;
            }

        }
        
    }

}

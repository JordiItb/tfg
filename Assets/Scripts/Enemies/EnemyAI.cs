using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform[] trackPoints;
    public float walkSpeed;
    public float rotationSpeed;
    int currentPoint;
    Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        currentPoint = 0;
    }

    
    void Update()
    {
        
        Wander();
        
    }

    void Wander(){

        if(trackPoints[currentPoint].position != transform.position){

            //Move to the target point
            transform.position = Vector3.SmoothDamp(transform.position, trackPoints[currentPoint].position, ref velocity, walkSpeed, walkSpeed);

            // Determine which direction to rotate towards
            Vector3 targetDirection = new Vector3(trackPoints[currentPoint].position.x - transform.position.x, 0f, trackPoints[currentPoint].position.z - transform.position.z);

            // The step size is equal to speed times frame time.
            float singleStep = rotationSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);

        }

    }

    void OnTriggerEnter(Collider collision){

        if(collision.gameObject.layer == 13 && collision.gameObject == trackPoints[currentPoint].gameObject){
            ChangePosition();
        }

    }

    void ChangePosition(){

        if(currentPoint == trackPoints.Length - 1){
            currentPoint = 0;
        }else{
            currentPoint ++;
        }

    }
}

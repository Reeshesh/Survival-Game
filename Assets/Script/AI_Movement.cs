using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
 
    Animator animator;
   
    public float moveSpeed = 3.5f;
 
    Vector3 stopPosition;
 
    float walkTime;
    public float walkCounter;
    float waitTime;
    public float waitCounter;
 
    int WalkDirection;
 
    public bool isWalking;

    public Transform playerTransform;


    public float chaseRange = 35f;
    public float rotationSpeed = 5f;


 
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();

         GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
    
    // Check if the player object was found
    if (playerObject != null)
    {
        // Assign the player's transform to the playerTransform variable
        playerTransform = playerObject.transform;
    }
    else
    {
        Debug.LogError("Player object not found in the scene. Make sure it has the correct tag.");
    }
 
        //So that all the prefabs don't move/stop at the same time
        walkTime = Random.Range(3,6);
        waitTime = Random.Range(5,7);
 
 
        waitCounter = waitTime;
        walkCounter = walkTime;
 
        ChooseDirection();
    }
 
    // Update is called once per frame
    void Update()
    {
       
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.transform.position);

        // Check if the player is within a certain range
        if (distanceToPlayer < chaseRange)
        {
        // Chase the player
            ChasePlayer();
        }
        else
        {
            // Wander around
            Wander();
        }
    }


    void ChasePlayer()
    {
        animator.SetBool("isRunning", true);

        // Get the direction from the animal to the player
        Vector3 direction = (playerTransform.position - transform.position).normalized;

        // Set the rotation of the animal to face the player
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Move towards the player
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }


    void Wander()
    {
        if (isWalking)
        {
            animator.SetBool("isRunning", true);
 
            walkCounter -= Time.deltaTime;
 
            switch (WalkDirection)
            {
                case  0:
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case  1:
                    transform.localRotation = Quaternion.Euler(0f, 90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case  2:
                    transform.localRotation = Quaternion.Euler(0f, -90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case  3:
                    transform.localRotation = Quaternion.Euler(0f, 180, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
            }
 
            if (walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isWalking = false;
                //stop movement
                transform.position = stopPosition;
                animator.SetBool("isRunning", false);
                //reset the waitCounter
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
 
            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }

 
    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
 
        isWalking = true;
        walkCounter = walkTime;
    }
}
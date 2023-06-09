using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;
    
    public float rotationSpeed = 0.01f;
    float timeCount = 0.0f;
    public Vector3 movement;

    public Animator anim;

    public bool enabled = true;
    public bool isDogWalking = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        isDogWalking = false;
        //anim = GetComponent<Animator>();
    }

   
    
    void Update()
    {
        anim.SetBool("isWalking", isDogWalking);
        
        if (enabled)
        {
            // Get player input
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput == 0 && verticalInput == 0) isDogWalking = false;
            else isDogWalking = true;

            // Set player movement based on input
            movement = new Vector3(horizontalInput, 0f, verticalInput);
            controller.Move(movement.normalized * speed * Time.deltaTime);
       
            if (movement.magnitude > 0)
            {
            
                //transform.rotation = Quaternion.LookRotation(movement);
            
            
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement),   rotationSpeed);
                timeCount = timeCount + Time.deltaTime;
            }

        }
        
    }
     

        

    }



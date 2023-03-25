using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        // Get player input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Set player movement based on input
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        controller.Move(movement.normalized * speed * Time.deltaTime);

        // Set player rotation towards movement direction
        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

    }
}


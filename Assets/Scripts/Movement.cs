using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 10f;

    public CharacterController player;

    private Vector3 direction;
    
    void Start()
    {
        direction = new Vector3();
        player = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        player.Move(new Vector3(transform.right.x * direction.x, 0, transform.forward.z * direction.z) * Time.deltaTime *
                    movementSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;

    public Vector3 camOffset = new Vector3(0, 10, -8);
    void Start()
    {
        FindPlayer();
    }

    
    void Update()
    {
        transform.position = player.position + camOffset;
    }

    public void FindPlayer()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
}

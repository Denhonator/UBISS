using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Obstacle : MonoBehaviour
{
    public CameraScript player;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) {
        rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, -rb.velocity.z);
        if (other.name.Contains("Controller")){
            
        }
        else
            player.GotHit(transform);
    }
}

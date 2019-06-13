using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Obstacle : MonoBehaviour
{
    public CameraScript player;
    Rigidbody rb;
    public SteamVR_Action_Vibration hapticAction = SteamVR_Input.GetAction<SteamVR_Action_Vibration>("Haptic");
    SteamVR_Input_Sources handType;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) {
        rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, -rb.velocity.z);
        player.GotHit(transform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Controller"))
        {
            handType = collision.gameObject.name.Contains("right") ? SteamVR_Input_Sources.RightHand : SteamVR_Input_Sources.LeftHand;
            hapticAction.Execute(0, 0.2f, 200, 1, handType);
        }
    }
}

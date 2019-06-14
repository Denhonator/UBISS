using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Bird : MonoBehaviour
{
    public CameraScript player;
    public SteamVR_Action_Vibration hapticAction = SteamVR_Input.GetAction<SteamVR_Action_Vibration>("Haptic");
    SteamVR_Input_Sources handType;
    Vector3 startPos;
    Quaternion startRot;
    public float speed = 3;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.right*speed;
        startPos = transform.position;
        startRot = transform.rotation;
        GetComponent<AudioSource>().time = Random.Range(0.0f, 3.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Controller"))
        {
            handType = collision.gameObject.name.Contains("right") ? SteamVR_Input_Sources.RightHand : SteamVR_Input_Sources.LeftHand;
            hapticAction.Execute(0, 0.2f, 200, 1, handType);
        }
        if (collision.gameObject.name.Contains("Chest"))
        {
            player.GotHit(transform);
            GetComponent<AudioSource>().Play();
        }
        rb.useGravity = true;
    }

    private void Update()
    {
        if(rb.useGravity)
            rb.AddForce(transform.forward);
        if (transform.position.y < -100 || transform.position.x > 50)
        {
            transform.position = startPos;
            transform.rotation = startRot;
            rb.velocity = Vector3.right*speed;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Obstacle : MonoBehaviour
{
    public CameraScript player;
    public SteamVR_Action_Vibration hapticAction = SteamVR_Input.GetAction<SteamVR_Action_Vibration>("Haptic");
    SteamVR_Input_Sources handType;

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
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
    }
}

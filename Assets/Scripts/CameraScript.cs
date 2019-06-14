using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CameraScript : MonoBehaviour
{
    public int duration = 10;
    public float offset = 0.1f;
    public SteamVR_Action_Boolean resetAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");
    public static bool shaking = false;

    public void GotHit(Transform other) {
        Vector3 vel = other.GetComponent<Rigidbody>().velocity;
        if(vel.sqrMagnitude*other.GetComponent<Rigidbody>().mass>20.0f && (transform.position - other.position).sqrMagnitude<2)
            StartCoroutine(Shake((transform.position - other.position).normalized));
    }

    private void Update()
    {
        if (resetAction.GetState(SteamVR_Input_Sources.Any))
        {
            transform.parent.parent.rotation = Quaternion.Euler(0, -transform.localRotation.eulerAngles.y, 0);
            transform.parent.parent.position -= new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    private void Start()
    {
        StartCoroutine(StartUp());
    }

    IEnumerator StartUp()
    {
        yield return new WaitForSeconds(1.0f);
        transform.parent.parent.rotation = Quaternion.Euler(0, -transform.rotation.eulerAngles.y, 0);
        transform.parent.parent.position -= new Vector3(transform.position.x, 0, transform.position.z);
    }

    IEnumerator Shake(Vector3 dir)
    {
        shaking = true;
        SteamVR_Fade.View(Color.black, 0);
        SteamVR_Fade.View(Color.clear, 1);
        for (int i = 1; i <= duration; i++)
        {
            transform.parent.localPosition = dir * offset * i;
            yield return new WaitForEndOfFrame();
        }
        for (int i = duration - 1; i >= 0; i--)
        {
            transform.parent.localPosition = dir * offset * i;
            yield return new WaitForEndOfFrame();
        }
        shaking = false;
    }
}

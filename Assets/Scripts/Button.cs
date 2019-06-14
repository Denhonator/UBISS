using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Button : MonoBehaviour
{

    public Vector3 move;

    private void OnTriggerEnter(Collider other)
    {
        if (!CameraScript.shaking && other.gameObject.name.Contains("Controller"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(GetComponent<Collider>());
            Destroy(GameObject.Find("Environment"));
            foreach(AudioSource a in FindObjectsOfType<AudioSource>())
            {
                a.loop = false;
            }
            foreach(Obstacle o in FindObjectsOfType<Obstacle>())
            {
                Destroy(o);
            }
            StartCoroutine(Push());
            SteamVR_Fade.View(Color.clear, 0);
            SteamVR_Fade.View(Color.black, 1);
        }
    }

    IEnumerator Push()
    {
        for(int i = 0; i<10; i++)
        {
            transform.localPosition -= move;
            yield return new WaitForEndOfFrame();
        }
        for (int i = 0; i < 10; i++)
        {
            transform.localPosition += move;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(10.0f);
        Application.Quit();
    }
}

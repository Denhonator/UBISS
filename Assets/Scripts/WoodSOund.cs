using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSOund : MonoBehaviour
{
    void Update()
    {
        if ((int)Time.unscaledTime%10==6 && Time.unscaledTime - (int)Time.unscaledTime < 0.02f && Random.Range(0,10)>7)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int duration = 10;
    public float offset = 0.1f;
    private void OnTriggerEnter(Collider other) {
        StartCoroutine(Shake());
    }

    IEnumerator Shake(){
        for(int i = 0; i<duration; i++){
            transform.parent.position += transform.parent.forward*offset;
            yield return new WaitForEndOfFrame();
        }
        for(int i = 0; i<duration; i++){
            transform.parent.position -= transform.parent.forward*offset;
            yield return new WaitForEndOfFrame();
        }
    }
}

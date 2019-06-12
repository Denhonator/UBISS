using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int duration = 10;
    public float offset = 0.1f;

    private void OnTriggerEnter(Collider other) {
        Vector3 vel = other.transform.GetComponent<Rigidbody>().velocity;
        other.transform.GetComponent<Rigidbody>().velocity = new Vector3(-vel.x,vel.y,-vel.z);
        Debug.Log(vel.sqrMagnitude);
        if(vel.sqrMagnitude<10.0f)
            return;
        StartCoroutine(Shake((transform.parent.position - other.transform.position).normalized));
    }
    private void OnCollisionEnter(Collision other) {
        Vector3 vel = other.transform.GetComponent<Rigidbody>().velocity;
        other.transform.GetComponent<Rigidbody>().velocity = new Vector3(-vel.x,vel.y,-vel.z);
        Debug.Log(vel.sqrMagnitude);
        if(vel.sqrMagnitude<0.2f)
            return;
        StartCoroutine(Shake((transform.parent.position - other.transform.position).normalized));
    }

    private void Start() {
        StartCoroutine(StartUp());
    }

    IEnumerator StartUp() {
        yield return new WaitForSeconds(1.5f);
        transform.parent.parent.rotation = Quaternion.Euler(0,-transform.rotation.eulerAngles.y,0);
        transform.parent.parent.position -= new Vector3(transform.position.x,0,transform.position.z);
    }

    IEnumerator Shake(Vector3 dir){
        for(int i = 1; i<=duration; i++){
            transform.parent.localPosition = dir*offset*i;
            yield return new WaitForEndOfFrame();
        }
        for(int i = duration-1; i>=0; i--){
            transform.parent.localPosition = dir*offset*i;
            yield return new WaitForEndOfFrame();
        }
    }
}

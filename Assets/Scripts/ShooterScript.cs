using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject sphere;
    public Transform playerCamera;
    public float accuracy = 1;
    float strength = 0.7f;
    float timer = 0;

    void Update()
    {
        if (timer > delay)
        {
            StartCoroutine(Shoot());
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    IEnumerator Shoot(){
        sphere.GetComponent<Collider>().isTrigger = false;
        sphere.transform.position = transform.position;
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        sphere.GetComponent<Collider>().isTrigger = true;
        Vector3 toPlayer = (playerCamera.position-transform.position);
        toPlayer.x += Random.Range(-accuracy,accuracy);
        toPlayer.y += 10.0f;
        toPlayer.z += Random.Range(-accuracy,accuracy);
        rb.AddForce(toPlayer*strength, ForceMode.Impulse);
    }
}

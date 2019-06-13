using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShooterScript : MonoBehaviour
{
    public GameObject sphere;
    public Transform playerCamera;
    public float accuracy = 1;
    public float delay = 3.5f;
    public float strength = 0.7f;
    float timer = 0;

    public GameObject cannon;
    public GameObject nozzle;

    void Update()
    {
        if (timer > delay)
        {
            Shoot();
            timer = 0;
        }
        timer += Time.deltaTime;

        cannon.transform.DOLookAt(playerCamera.transform.position, .1f, AxisConstraint.None);
    }

    void Shoot()
    {
        GetComponent<AudioSource>().Play();
        sphere.GetComponent<Collider>().isTrigger = false;
        sphere.transform.position = nozzle.transform.position;
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        Vector3 toPlayer = cannon.transform.forward * (playerCamera.position-transform.position).magnitude;
        toPlayer.x += Random.Range(-accuracy, accuracy);
        toPlayer.y += 10.0f;
        toPlayer.z += Random.Range(-accuracy, accuracy);
        rb.AddForce(toPlayer * (strength + Random.Range(-strength*0.1f,strength*0.1f)), ForceMode.Impulse);
    }
}

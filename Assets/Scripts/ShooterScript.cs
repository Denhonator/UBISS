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
            StartCoroutine(Shoot());
            timer = 0;
        }
        timer += Time.deltaTime;

        cannon.transform.DOLookAt(playerCamera.transform.position, .1f, AxisConstraint.None);
    }

    IEnumerator Shoot()
    {
        sphere.GetComponent<Collider>().isTrigger = false;
        sphere.transform.position = nozzle.transform.position;
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        yield return null;
        Vector3 toPlayer = (playerCamera.position - transform.position);
        toPlayer.x += Random.Range(-accuracy, accuracy);
        toPlayer.y += 10.0f;
        toPlayer.z += Random.Range(-accuracy, accuracy);
        rb.AddForce(toPlayer * strength, ForceMode.Impulse);
    }
}

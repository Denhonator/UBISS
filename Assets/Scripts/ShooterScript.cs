using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject sphere;
    public Transform playerCamera;
    public float strength = 0.7f;
    public float delay = 3.5f;
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

    IEnumerator Shoot()
    {
        sphere.transform.position = transform.position;
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        Vector3 toPlayer = (playerCamera.position - transform.position);
        toPlayer.x += Random.Range(-5.0f, 5.0f);
        toPlayer.y += 10.0f;
        toPlayer.z += Random.Range(-5.0f, 5.0f);
        rb.AddForce(toPlayer * strength, ForceMode.Impulse);
    }
}

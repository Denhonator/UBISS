using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Shoot", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        //sphere.transform.position = new Vector3(10, 1, 5);
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        rb.AddForce(-50, 0, 0, ForceMode.Impulse);
    }
}

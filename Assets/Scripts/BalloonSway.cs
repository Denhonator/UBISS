using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSway : MonoBehaviour

{
    Quaternion startRot = Quaternion.Euler(0, 0, 0);
    float swayoffset = 0;
    public float swaySpeed = 1;
    public float swayAmount;
    // Start is called before the first frame update
    void Start()
    {
       startRot = transform.rotation;
       swayoffset = Random.Range(0, 6);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = startRot * Quaternion.Euler(Mathf.Sin(swaySpeed * Time.time + swayoffset) * swayAmount, 0, Mathf.Sin(swaySpeed * Time.time + swayoffset) * swayAmount);
        
    }
}

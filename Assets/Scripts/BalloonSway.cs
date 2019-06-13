using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSway : MonoBehaviour

{
    Vector3 startPos = new Vector3(0, 0, 0);
    float swayoffset = 0;
    public float swaySpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
       startPos = transform.position;
       swayoffset = Random.Range(0, 6);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + new Vector3(Mathf.Sin(Time.deltaTime + swayoffset),0, Mathf.Sin(Time.deltaTime + swayoffset));
        
    }
}

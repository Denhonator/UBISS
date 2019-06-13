using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.up * Mathf.Sin(Time.unscaledTime * 0.2f) * 2);
    }
}

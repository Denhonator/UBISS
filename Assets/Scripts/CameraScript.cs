using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int duration = 10;
    public float offset = 0.1f;

    public void GotHit(Transform other) {
        Vector3 vel = other.GetComponent<Rigidbody>().velocity;
        if(vel.sqrMagnitude>20.0f && (transform.position - other.position).sqrMagnitude<2)
            StartCoroutine(Shake((transform.position - other.position).normalized));
    }

    private void Start()
    {
        StartCoroutine(StartUp());
    }

    IEnumerator StartUp()
    {
        yield return new WaitForSeconds(1.5f);
        transform.parent.parent.rotation = Quaternion.Euler(0, -transform.rotation.eulerAngles.y, 0);
        transform.parent.parent.position -= new Vector3(transform.position.x, 0, transform.position.z);
    }

    IEnumerator Shake(Vector3 dir)
    {
        for (int i = 1; i <= duration; i++)
        {
            transform.parent.localPosition = dir * offset * i;
            yield return new WaitForEndOfFrame();
        }
        for (int i = duration - 1; i >= 0; i--)
        {
            transform.parent.localPosition = dir * offset * i;
            yield return new WaitForEndOfFrame();
        }
    }
}

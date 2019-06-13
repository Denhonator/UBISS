using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFadeImageTry : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Fade());
        }
    }

    public IEnumerator Fade()
    {
        target.SetActive(true);
        target.GetComponent<SpriteRenderer>().DOFade(0, 1);
        yield return new WaitForSeconds(1);
        target.SetActive(false);
        target.GetComponent<SpriteRenderer>().DOFade(1, 0);
    }
}

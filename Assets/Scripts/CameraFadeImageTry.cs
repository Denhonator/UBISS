using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFadeImageTry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fade()
    {
        Transform image = GameObject.Find("images").transform.Find("cropped-favicon");
        image.gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1);
    }
}

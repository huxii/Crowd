using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IconBehavior : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Close()
    {
        transform.DOScale(new Vector3(0, 0, 0), 0.5f)
            .OnComplete(
            () => { Destroy(gameObject); }
            );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FootprintsBehavior : MonoBehaviour
{
    public GameObject leftFootprint;
    public GameObject rightFootPrint;
    public float footprintDuration = 1f;

    private float destroyTimer = 0;

    // Use this for initialization
    void Start()
    {
        leftFootprint.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        rightFootPrint.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        leftFootprint.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), footprintDuration)
            .SetEase(Ease.OutCubic);
        rightFootPrint.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), footprintDuration)
            .SetDelay(footprintDuration * 0.5f)
            .SetEase(Ease.OutCubic)
            .OnComplete(
            () => { destroyTimer = 2f; }
            );
    }

    void Update()
    {
        if (destroyTimer > 0)
        {
            destroyTimer -= Time.deltaTime;
            if (destroyTimer <= 0)
            {
                FadeOut();              
            }
        }
    }

    public void FadeOut()
    {
        leftFootprint.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), footprintDuration)
       .SetEase(Ease.OutCubic);
        rightFootPrint.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), footprintDuration)
            .SetEase(Ease.OutCubic)
            .OnComplete(
            () => { destroyTimer = 0; Destroy(gameObject); }
            );
    }
}

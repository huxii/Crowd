using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStreamControl : MonoBehaviour
{
    public int levelIdx = -1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Man"))
        {
            if (levelIdx == -1)
            {
                Services.hudController.PlayNextUIEvent();
            }
            else
            {
                Services.hudController.PlayUIEvent(levelIdx);
            }

            Destroy(gameObject);
        }
    }
}

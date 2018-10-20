using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyAnimation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            Destroy(gameObject);
        }
    }
}

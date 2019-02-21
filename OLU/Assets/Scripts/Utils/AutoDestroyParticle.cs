using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticle : MonoBehaviour
{
    private float timer = 0;

    // Use this for initialization
    void Start()
    {
        timer = GetComponent<ParticleSystem>().duration * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
        //if (!GetComponent<ParticleSystem>().isPlaying)
        //{
        //    Destroy(gameObject);
        //}
    }
}

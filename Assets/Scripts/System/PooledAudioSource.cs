using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledAudioSource : MonoBehaviour {
    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!audio.isPlaying)
        {
            Invoke("Destroy", 0f);
        }
	}

    void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodSoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMOD.Studio.EventInstance instance = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        instance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

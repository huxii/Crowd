using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodControl : MonoBehaviour
{
    private FMOD.Studio.EventInstance bgmInstance;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SoundSystem");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        bgmInstance = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        bgmInstance.start();
    }

    public void BGMTransition(string name, float value)
    {
        bgmInstance.setParameterValue(name, value);
    }    
}

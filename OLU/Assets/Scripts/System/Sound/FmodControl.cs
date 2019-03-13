using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodControl : MonoBehaviour
{
    // BGM
    private FMOD.Studio.EventInstance bgmInstance;
    private string[] LEVEL_BGM_PARAS =
    {
        "",
        "TutorialTransition",
        "Level0Transition",
        "Level1Transition",
        "Level2Transition",
    };

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
        if (Services.sceneController.CurrentSceneIdx() == 0)
        {
            bgmInstance.start();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            ResetBGM();
        }
        else
        {
            bgmInstance.setParameterValue(LEVEL_BGM_PARAS[level], 1);
            bgmInstance.setParameterValue(LEVEL_BGM_PARAS[level] + "_extra", 1);
        }
    }

    public void ResetBGM()
    {
        for (int i = 0; i < LEVEL_BGM_PARAS.Length; ++i)
        {
            bgmInstance.setParameterValue(LEVEL_BGM_PARAS[i], 0);
            bgmInstance.setParameterValue(LEVEL_BGM_PARAS[i] + "_extra", 1);
        }
    }

    public void SetBGMTransition(float value)
    {
        int idx = Services.sceneController.CurrentSceneIdx();
        bgmInstance.setParameterValue(LEVEL_BGM_PARAS[idx], value);
    }

    public void SetExtraBGMTransition(float value)
    {
        int idx = Services.sceneController.CurrentSceneIdx();
        bgmInstance.setParameterValue(LEVEL_BGM_PARAS[idx] + "_extra", value);
    }    
}

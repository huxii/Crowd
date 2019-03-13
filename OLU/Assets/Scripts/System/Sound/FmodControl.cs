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
    private float outerVolume = 1.0f;
    private float innerVolume = 0.6f;

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
            bgmInstance.setParameterValue(LEVEL_BGM_PARAS[level], outerVolume);
        }
    }

    public void ResetBGM()
    {
        for (int i = 1; i < LEVEL_BGM_PARAS.Length; ++i)
        {
            bgmInstance.setParameterValue(LEVEL_BGM_PARAS[i], 0);
            //// wtf????
            //float value = 0;
            //float finalValue = 0;
            //bgmInstance.getParameterValue(LEVEL_BGM_PARAS[i], out value, out finalValue);

            //Services.taskManager
            //    .Do(new FmodInstanceTask(bgmInstance, LEVEL_BGM_PARAS[i], value, 0, 1));
        }
    }

    public void SetInnerBGM()
    {
        int idx = Services.sceneController.CurrentSceneIdx();

        // wtf????
        float value = 0;
        float finalValue = 0;
        bgmInstance.getParameterValue(LEVEL_BGM_PARAS[idx], out value, out finalValue);

        Services.taskManager
            .Do(new FmodInstanceTask(bgmInstance, LEVEL_BGM_PARAS[idx], value, innerVolume, 1));
    }

    public void SetOuterBGM()
    {
        int idx = Services.sceneController.CurrentSceneIdx();

        // wtf????
        float value = 0;
        float finalValue = 0;
        bgmInstance.getParameterValue(LEVEL_BGM_PARAS[idx], out value, out finalValue);

        Services.taskManager
            .Do(new FmodInstanceTask(bgmInstance, LEVEL_BGM_PARAS[idx], value, outerVolume, 1));
    }
}

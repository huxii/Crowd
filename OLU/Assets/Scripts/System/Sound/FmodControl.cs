using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodControl
{
    // BGM
    private FMOD.Studio.EventInstance bgmInstance;
    private string LEVEL_OUTER_BGM_PARAS = "OuterBGMTransition";
    private string[] LEVEL_BGM_PARAS =
    {
        "",
        "TutorialTransition",
        "Level0Transition",
        "Level1Transition",
        "Level2Transition",
    };

    public void Init()
    {
        bgmInstance = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        if (Services.sceneController.CurrentSceneIdx() == 0)
        {
            bgmInstance.start();
        }
    }

    public void UpdateBGM(int level)
    {
        if (level == 0)
        {
            ResetBGM();
        }
        else
        {
            bgmInstance.setParameterValue(LEVEL_BGM_PARAS[level], 1.0f);
            bgmInstance.setParameterValue(LEVEL_OUTER_BGM_PARAS, 1.0f);
        }
    }

    public void ResetBGM()
    {
        bgmInstance.setParameterValue(LEVEL_OUTER_BGM_PARAS, 1.0f);
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
        // wtf????
        float value = 0;
        float finalValue = 0;
        bgmInstance.getParameterValue(LEVEL_OUTER_BGM_PARAS, out value, out finalValue);

        Services.taskManager
            .Do(new FmodInstanceTask(bgmInstance, LEVEL_OUTER_BGM_PARAS, value, 0, 1));
    }

    public void SetOuterBGM()
    {
        // wtf????
        float value = 0;
        float finalValue = 0;
        bgmInstance.getParameterValue(LEVEL_OUTER_BGM_PARAS, out value, out finalValue);

        Services.taskManager
            .Do(new FmodInstanceTask(bgmInstance, LEVEL_OUTER_BGM_PARAS, value, 1, 1));
    }
}

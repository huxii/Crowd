using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Spine.Unity;

public class CrowdFeedbackBehavior : InteractableFeedbackBehavior
{
    void Awake()
    {
        if (targetObj == null)
        {
            targetObj = gameObject;
        }
        SkeletonDataAsset data = targetObj.GetComponentInChildren<SkeletonAnimation>().skeletonDataAsset;

        Material spineMat = data.atlasAssets[0].materials[0];
        Material newMat = Instantiate(Instantiate(spineMat));
        AtlasAsset newAtlas = Instantiate(data.atlasAssets[0]);
        SkeletonDataAsset newData = Instantiate(data);

        newData.atlasAssets[0] = newAtlas;
        newAtlas.materials[0] = newMat;
        GetComponentInChildren<SkeletonAnimation>().skeletonDataAsset = newData;
        GetComponentInChildren<SkeletonAnimation>().Initialize(true);

        mats.Add(newMat);

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFactors();
    }
}
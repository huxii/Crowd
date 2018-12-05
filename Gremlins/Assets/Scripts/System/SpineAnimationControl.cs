using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimationControl : MonoBehaviour
{
    Dictionary<string, int> animList = new Dictionary<string, int>();
    SkeletonAnimation anim;

    char[] splitter = { ' ', ',' };

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<SkeletonAnimation>();
      
        TextAsset textAsset = Resources.Load<TextAsset>("SpineData/SpineAnimationList");
        string texts = textAsset.text;
        string[] lines = texts.Split('\n', '\r');
        for (int i = 1; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(splitter);
            if (row[0] == "1")
            {
                string name = row[1];
                int track = 0;
                int.TryParse(row[2], out track);
                animList.Add(name, track);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAnimation(string name, bool clearOther = false)
    {
        if (!animList.ContainsKey(name))
        {
            return;
        }

        var state = anim.state;
        int track = animList[name];
        if (clearOther)
        {
            for (int i = 0; i < 5; ++i)
            {
                if (i != track)
                {
                    state.ClearTrack(i);
                }
            }
        }

        if (state.GetCurrent(track) == null || state.GetCurrent(track).Animation == null || state.GetCurrent(track).Animation.Name != name)
        {
            state.SetAnimation(animList[name], name, true);
        }
    }
}

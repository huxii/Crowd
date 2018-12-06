using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Spine.Unity;

public class SpineAnimClip
{
    public int track;
    public bool isLooping;
}

public class SpineAnimationControl : MonoBehaviour
{
    public enum ClearPolicy
    {
        DONT,
        CLEARTHIS,
        CLEARALL,
        CLEARNOTFACIAL,
        CLEARNOTBODY,
        CLEARNOTSPECIAL,
        CLEARBODY,          // 0, 1
        CLEARFACIAL,        // 3, 4
        CLEARSPECIAL,       // 2
    }

    Dictionary<string, SpineAnimClip> animList = new Dictionary<string, SpineAnimClip>();
    SkeletonAnimation anim;

    char[] splitter = { ' ', ',' };
    private float mixTime = 0.5f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<SkeletonAnimation>();
        anim.state.Complete += OnComplete;

        TextAsset textAsset = Resources.Load<TextAsset>("SpineData/SpineAnimationList");
        string texts = textAsset.text;
        string[] lines = texts.Split('\n', '\r');
        for (int i = 1; i < lines.Length; i++)
        {          
            string[] row = lines[i].Split(splitter);
            if (row[0] == "1")
            {
                SpineAnimClip clip = new SpineAnimClip();
                string name = row[1];
                int.TryParse(row[2], out clip.track);
                bool.TryParse(row[3], out clip.isLooping);
                animList.Add(name, clip);
            }
        }

        SetAnimation("eye_blink");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnComplete(Spine.TrackEntry entry)
    {
        if (!entry.Loop)
        {
            // if this animation is not looping
            // pick another animation in the same group
            string name = entry.Animation.Name;
            string[] names = name.Split('_');
            SetRandomAnimation(names[0], ClearPolicy.CLEARNOTFACIAL, name);
        }
    }

    public void SetAnimation(string name, ClearPolicy clearPolicy = ClearPolicy.DONT)
    {
        if (!animList.ContainsKey(name))
        {
            return;
        }

        var state = anim.state;
        int track = animList[name].track;
        switch (clearPolicy)
        {
            case ClearPolicy.CLEARALL:
                for (int i = 0; i < 5; ++i)
                {
                    state.SetEmptyAnimation(i, mixTime);
                }
                break;
            case ClearPolicy.CLEARBODY:
                state.SetEmptyAnimation(0, mixTime);
                state.SetEmptyAnimation(1, mixTime);
                break;
            case ClearPolicy.CLEARFACIAL:
                state.SetEmptyAnimation(3, mixTime);
                state.SetEmptyAnimation(4, mixTime);
                break;
            case ClearPolicy.CLEARSPECIAL:
                state.SetEmptyAnimation(2, mixTime);
                break;
            case ClearPolicy.CLEARNOTFACIAL:
                for (int i = 0; i < 3; ++i)
                {
                    if (i != track)
                    {
                        state.SetEmptyAnimation(i, mixTime);
                    }
                }
                break;
            case ClearPolicy.CLEARNOTBODY:
                for (int i = 2; i < 5; ++i)
                {
                    if (i != track)
                    {
                        state.SetEmptyAnimation(i, mixTime);
                    }
                }
                break;
            case ClearPolicy.CLEARNOTSPECIAL:
                for (int i = 0; i < 5; ++i)
                {
                    if (i != track && i != 2)
                    {
                        state.SetEmptyAnimation(i, mixTime);
                    }
                }
                break;
            case ClearPolicy.CLEARTHIS:
                state.SetEmptyAnimation(track, mixTime);
                break;
            case ClearPolicy.DONT:
            default:
                break;
            
        }

        if (state.GetCurrent(track) == null || state.GetCurrent(track).Animation == null || state.GetCurrent(track).Animation.Name != name)
        {
            state.SetAnimation(track, name, animList[name].isLooping);
        }
    }

    public void SetRandomAnimation(string name, ClearPolicy clearPolicy = ClearPolicy.DONT, string exception = null)
    {
        var query = (animList.Where(x => x.Key.Contains(name) && x.Key != exception)).ToList();
        if (query.Count > 0)
        {
            int rand = Random.Range(0, query.Count);
            SetAnimation(query[rand].Key, clearPolicy);
        }
    }
}

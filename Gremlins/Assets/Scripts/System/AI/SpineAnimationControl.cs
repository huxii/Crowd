using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Spine.Unity;

public class SpineAnimClip
{
    public enum LoopType
    {
        LOOP,
        NOTLOOP_REPLACE,
        NOTLOOP_KEEP
    }

    public int track;
    public LoopType loopType;
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
    const float mixTime = 0.5f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponentInChildren<SkeletonAnimation>();
        anim.state.Complete += OnComplete;

        TextAsset textAsset = Resources.Load<TextAsset>("Rosters/SpineAnimationList");
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

                switch (row[3])
                {
                    case "LOOP":
                        clip.loopType = SpineAnimClip.LoopType.LOOP;
                        break;
                    case "NOTLOOP_REPLACE":
                        clip.loopType = SpineAnimClip.LoopType.NOTLOOP_REPLACE;
                        break;
                    case "NOTLOOP_KEEP":
                        clip.loopType = SpineAnimClip.LoopType.NOTLOOP_KEEP;
                        break;
                }

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
        string name = entry.Animation.Name;
        if (!animList.ContainsKey(name))
        {
            return;
        }

        SpineAnimClip clip = animList[name];
        if (clip.loopType == SpineAnimClip.LoopType.NOTLOOP_REPLACE)
        {
            // if this animation is not looping
            // pick another animation in the same group
            string[] names = name.Split('_');
            SetRandomAnimation(names[0], ClearPolicy.CLEARNOTFACIAL, name);
        }
    }

    public void SetAnimation(string name, ClearPolicy clearPolicy = ClearPolicy.DONT, float mix = mixTime)
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
                    state.SetEmptyAnimation(i, mix);
                }
                break;
            case ClearPolicy.CLEARBODY:
                state.SetEmptyAnimation(0, mix);
                state.SetEmptyAnimation(1, mix);
                break;
            case ClearPolicy.CLEARFACIAL:
                state.SetEmptyAnimation(3, mix);
                state.SetEmptyAnimation(4, mix);
                break;
            case ClearPolicy.CLEARSPECIAL:
                state.SetEmptyAnimation(2, mix);
                break;
            case ClearPolicy.CLEARNOTFACIAL:
                for (int i = 0; i < 3; ++i)
                {
                    if (i != track)
                    {
                        state.SetEmptyAnimation(i, mix);
                    }
                }
                break;
            case ClearPolicy.CLEARNOTBODY:
                for (int i = 2; i < 5; ++i)
                {
                    if (i != track)
                    {
                        state.SetEmptyAnimation(i, mix);
                    }
                }
                break;
            case ClearPolicy.CLEARNOTSPECIAL:
                for (int i = 0; i < 5; ++i)
                {
                    if (i != track && i != 2)
                    {
                        state.SetEmptyAnimation(i, mix);
                    }
                }
                break;
            case ClearPolicy.CLEARTHIS:
                state.SetEmptyAnimation(track, mix);
                break;
            case ClearPolicy.DONT:
            default:
                break;

        }

        if (state.GetCurrent(track) == null || state.GetCurrent(track).Animation == null || state.GetCurrent(track).Animation.Name != name)
        {
            //Debug.Log(name);
            state.SetAnimation(track, name, animList[name].loopType == SpineAnimClip.LoopType.LOOP);
        }
    }

    public void SetRandomAnimation(string name, ClearPolicy clearPolicy = ClearPolicy.DONT, string exception = null, float mix = mixTime)
    {
        var query = (animList.Where(x => x.Key.Contains(name) && x.Key != exception)).ToList();
        if (query.Count > 0)
        {
            int rand = Random.Range(0, query.Count);
            SetAnimation(query[rand].Key, clearPolicy, mix);
        }
    }

    public void ClearAnimation(string name, float mix = mixTime)
    {
        if (!animList.ContainsKey(name))
        {
            return;
        }

        var state = anim.state;
        int track = animList[name].track;
        state.SetEmptyAnimation(track, mix);
    }

    public void SetProgress(string name, float value)
    {
        if (!animList.ContainsKey(name))
        {
            return;
        }

        int track = animList[name].track;
        var trackEntry = anim.state.GetCurrent(track);
        if (trackEntry != null)
        {
            trackEntry.TrackTime = value;
        }
    }
}

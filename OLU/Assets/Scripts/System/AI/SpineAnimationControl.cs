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
    public float mixTime;
}

public class SpineAnimationControl : MonoBehaviour
{
    public static int CLEAR_FACIAL = (1 << 4) | (1 << 3);
    public static int CLEAR_BODY = (1 << 0) | (1 << 1);
    public static int CLEAR_SPECIAL = (1 << 2);
    public static int CLEAR_NOT_FACIAL = CLEAR_BODY | CLEAR_SPECIAL;
    public static int CLEAR_NOT_BODY = CLEAR_FACIAL | CLEAR_SPECIAL;
    //public static int CLEAR_THIS = (1 << 5);
    public static int CLEAR_ALL = ~(1 << 5);

    Dictionary<string, SpineAnimClip> animList = new Dictionary<string, SpineAnimClip>();
    SkeletonAnimation anim;

    char[] splitter = { ' ', ',' };

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

                float.TryParse(row[4], out clip.mixTime);

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
            // 15: clear all except 4
            string[] names = name.Split('_');
            SetRandomAnimation(names[0], CLEAR_NOT_FACIAL, name);
        }
    }

    public void SetAnimation(string name, int clearPolicy = 0)
    {
        if (!animList.ContainsKey(name))
        {
            return;
        }

        var state = anim.state;
        int track = animList[name].track;
        float mixTime = animList[name].mixTime;

        //int needClearThis = clearPolicy & (1 << 5);
        //if (needClearThis == 1)
        //{
        //    clearPolicy |= 1 << track;
        //}
        //else
        //{
        //    clearPolicy &= ~(1 << track);
        //}

        //Debug.Log(name);

        if (state.GetCurrent(track) == null || state.GetCurrent(track).Animation == null || state.GetCurrent(track).Animation.Name != name)
        {
            state.SetAnimation(track, name, animList[name].loopType == SpineAnimClip.LoopType.LOOP);
        }

        for (int i = 0; i < 5; ++i)
        {
            if (i != track)
            {
                int needClear = (clearPolicy & (1 << i)) >> i;
                if (needClear == 1)
                {
                    state.SetEmptyAnimation(i, mixTime);
                }

                //Debug.Log(clearPolicy + " " + i + " " + needClear);
            }
        }
    }

    public void SetRandomAnimation(string name, int clearPolicy = 0, string exception = null)
    {
        var query = (animList.Where(x => x.Key.Contains(name) && x.Key != exception)).ToList();
        if (query.Count > 0)
        {
            int rand = Random.Range(0, query.Count);
            SetAnimation(query[rand].Key, clearPolicy);
        }
    }

    public void ClearAnimation(string name)
    {
        if (!animList.ContainsKey(name))
        {
            return;
        }

        anim.state.SetEmptyAnimation(animList[name].track, animList[name].mixTime);
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

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
    Dictionary<string, SpineAnimClip> animList = new Dictionary<string, SpineAnimClip>();
    SkeletonAnimation anim;

    char[] splitter = { ' ', ',' };

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
            SetRandomAnimation(names[0], true, name);
        }
    }

    public void SetAnimation(string name, bool clearOther = false)
    {
        if (!animList.ContainsKey(name))
        {
            return;
        }

        var state = anim.state;
        int track = animList[name].track;
        if (clearOther)
        {
            for (int i = 0; i < 5; ++i)
            {
                if (i != track)
                {
                    state.SetEmptyAnimation(i, 0.5f);
                }
            }
        }

        if (state.GetCurrent(track) == null || state.GetCurrent(track).Animation == null || state.GetCurrent(track).Animation.Name != name)
        {
            state.SetAnimation(track, name, animList[name].isLooping);
        }
    }

    public void SetRandomAnimation(string name, bool clearOther = false, string exception = null)
    {
        var query = (animList.Where(x => x.Key.Contains(name) && x.Key != exception)).ToList();
        if (query.Count > 0)
        {
            int rand = Random.Range(0, query.Count);
            SetAnimation(query[rand].Key, clearOther);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class SoundClip
{
    public string id = null;
    public AudioClip audioClip = null;
    public int loop = 1; // -1: infinite
    public float startDelay = 0;
    public float fadeInDuration = 0;
    public float fadeOutDuration = 0;
    public float spatialBlend = 0;

    public enum DuplicatePolicy
    {
        NOTREPLACE,
        REPLACE,
        MULTIPLE,
    };
    public DuplicatePolicy duplicatePolicy = DuplicatePolicy.NOTREPLACE;

    public SoundClip() { }
}

public class SoundControl : MonoBehaviour
{
    public GameObject audioSourcePrefab;

    [SerializeField]
    private List<SoundClip> clips;
    private int pooledAudioAmount = 10; 

    List<GameObject> audioSources;
    Dictionary<string, SoundClip> soundList = new Dictionary<string, SoundClip>();

    char[] splitter = { ' ', ',' };

    // Use this for initialization
    void Start()
    {
        audioSources = new List<GameObject>();
        for (int i = 0; i < pooledAudioAmount; i++)
        {
            GameObject audio = (GameObject)Instantiate(audioSourcePrefab);
            audio.SetActive(false);
            audioSources.Add(audio);
        }

        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + "//Resources//Sounds//AudioList.csv");
        for (int i = 1; i < lines.Length; i++)
        {
            SoundClip clip = new SoundClip();
            if (lines[i][0] == '1')
            {
                string[] row = lines[i].Split(splitter);
                clip.id = row[1];
                clip.audioClip = Resources.Load<AudioClip>("Sounds/" + row[2]);
                int.TryParse(row[3], out clip.loop);
                float.TryParse(row[4], out clip.startDelay);
                float.TryParse(row[5], out clip.fadeInDuration);
                float.TryParse(row[6], out clip.fadeOutDuration);
                float.TryParse(row[7], out clip.spatialBlend);
                switch (row[8])
                {
                    case "NOTREPLACE":
                        clip.duplicatePolicy = SoundClip.DuplicatePolicy.NOTREPLACE;
                        break;
                    case "REPLACE":
                        clip.duplicatePolicy = SoundClip.DuplicatePolicy.REPLACE;
                        break;
                    case "MULTIPLE":
                        clip.duplicatePolicy = SoundClip.DuplicatePolicy.MULTIPLE;
                        break;
                }

                clips.Add(clip);
            }
        }

        foreach (SoundClip s in clips)
        {
            soundList.Add(s.id, s);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    // the way to judge if an audio source has been taken:
    // source.clip != null
    public void Play(string id)
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            AudioSource source = audioSources[i].GetComponent<AudioSource>();
            if (source.clip != null)
            {
                if (!source.isPlaying)
                {
                    source.clip = null;
                }
                else
                if (source.clip.name == soundList[id].audioClip.name)
                {
                    if (soundList[id].duplicatePolicy == SoundClip.DuplicatePolicy.NOTREPLACE)
                    {
                        return;
                    }
                    else
                    if (soundList[id].duplicatePolicy == SoundClip.DuplicatePolicy.REPLACE)
                    {
                        audioSources[i].SetActive(false);
                        break;
                    }
                    else
                    if (soundList[id].duplicatePolicy == SoundClip.DuplicatePolicy.MULTIPLE)
                    {
                    }
                }
            }
        }

        for (int i = 0; i < audioSources.Count; i++)
        {
            AudioSource source = audioSources[i].GetComponent<AudioSource>();
            if (source.clip == null)
            {
                source.playOnAwake = false;
                source.loop = (soundList[id].loop == -1);
                source.clip = soundList[id].audioClip;
                audioSources[i].SetActive(true);
                source.DOFade(1, soundList[id].fadeInDuration);
                source.PlayDelayed(soundList[id].startDelay);

                break;
            }
        }
    }

    public void Stop(string id, bool all = false)
    {
        foreach (GameObject source in audioSources)
        {
            Debug.Log(source.GetComponent<AudioSource>());
            if (source.GetComponent<AudioSource>().clip != null && source.GetComponent<AudioSource>().clip.name == soundList[id].audioClip.name)
            {
                source.GetComponent<AudioSource>().DOFade(0, soundList[id].fadeOutDuration).OnComplete(() => { source.SetActive(false); });
            }
            if (!all)
            {
                break;
            }

        }
    }
}

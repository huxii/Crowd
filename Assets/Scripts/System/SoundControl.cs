using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[System.Serializable]
public class SoundClip
{
    public string id = null;
    public AudioClip audioClip = null;
    public bool isLooping;
    public float delay;
    public float fadeInDuration;
    public float fadeOutDuration;
    public bool isFalloff = false;
    public bool isStandOut = false;
    public float spatialBlend = 0;
    public bool uniqueReturn = false;
    public bool uniqueReplace = false;

    public SoundClip() { }
}

public class SoundControl : MonoBehaviour {
    public List<SoundClip> clips;
    public int pooledAudioAmount = 10;
    List<GameObject> audioSources;
    public GameObject audioSource;
    Dictionary<string, SoundClip> soundList = new Dictionary<string, SoundClip>();

    // Use this for initialization
    void Start()
    {
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + "//Resources//Sounds//AudioList.csv");
        for (int i = 1; i < lines.Length; i++)
        {
            SoundClip clip = new SoundClip();
            if (lines[i][0] == '1')
            {
                string[] row = lines[i].Split(',');
                clip.id = row[1];
                Debug.Log(row[2]);
                clip.audioClip = Resources.Load<AudioClip>("Sounds/" + row[2]);
                clip.isLooping = row[3] == "1" ? true : false;
                float.TryParse(row[4], out clip.delay);
                float.TryParse(row[5], out clip.fadeInDuration);
                float.TryParse(row[6], out clip.fadeOutDuration);
                clip.isFalloff = row[7] == "1" ? true : false;
                clip.isStandOut = row[8] == "1" ? true : false;
                float.TryParse(row[9], out clip.spatialBlend);
                clip.uniqueReturn = row[10] == "1" ? true : false;
                clip.uniqueReplace = row[11] == "1" ? true : false;
                clips.Add(clip);
            }
        }
        
        audioSources = new List<GameObject>();
        for (int i = 0; i < pooledAudioAmount; i++)
        {
            GameObject audio = (GameObject)Instantiate(audioSource);
            audio.SetActive(false);
            audioSources.Add(audio);
        }

        foreach (SoundClip s in clips)
        {
            soundList.Add(s.id, s);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Play(string id)
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            AudioSource source = audioSources[i].GetComponent<AudioSource>();
            if (source.clip != null &&  source.clip.name == soundList[id].audioClip.name)
            {
                if (soundList[id].uniqueReturn)
                {
                    return;
                }
                else if (soundList[id].uniqueReplace)
                {
                    audioSources[i].SetActive(false);
                }
            }
        }
        for (int i = 0; i < audioSources.Count; i++)
        {
            AudioSource source = audioSources[i].GetComponent<AudioSource>();
            Debug.Log(audioSources[i]);
            if (!source.isPlaying)
            {
                source.loop = soundList[id].isLooping;
                source.clip = soundList[id].audioClip;
                audioSources[i].SetActive(true);
                source.DOFade(1, soundList[id].fadeInDuration);
                source.PlayDelayed(soundList[id].delay);

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

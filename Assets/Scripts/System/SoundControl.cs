using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class SoundClip
{
    public string id = null;
    public string clipName = null;
    public bool isLooping;
    public float delay;
    public float fadeInDuration;
    public float fadeOutDuration;
    public bool isFalloff = false;
    public bool isStandOut = false;
    public float spatialBlend = 0;
}

public class SoundControl : MonoBehaviour {
    List<SoundClip> clips;
    public int pooledAudioAmount = 10;
    List<GameObject> audioSources;
    public GameObject audioSource;
    Dictionary<string, SoundClip> soundList = new Dictionary<string, SoundClip>();

    // Use this for initialization
    void Start()
    {
        TextAsset soundlist = Resources.Load<TextAsset>("Audio List");

        string[] list = soundlist.text.Split(new char[] { '\n' });

        for (int i = 1; i < list.Length; i++)
        {
            if (list[i][0] == '1' )
            {
                string[] row = list[i].Split(new char[] { ',' });
                Debug.Log(row[0] + "   " + row[1]);
                SoundClip clip = new SoundClip();
                clip.id = row[1];
                clip.clipName = row[2];
                bool.TryParse(row[3], out clip.isLooping);
                float.TryParse(row[4], out clip.delay);
                float.TryParse(row[5], out clip.fadeInDuration);
                float.TryParse(row[6], out clip.fadeOutDuration);
                bool.TryParse(row[7], out clip.isFalloff);
                bool.TryParse(row[8], out clip.isStandOut);
                float.TryParse(row[9], out clip.spatialBlend);
                
                clips.Add(clip);
            }
        }

        foreach (SoundClip clip in clips) {
            Debug.Log(clip.id);
            Debug.Log(clip.clipName);
        }

        /*
        audioSources = new List<GameObject>();
        for (int i = 0; i < pooledAudioAmount; i++)
        {
            GameObject audio = (GameObject)Instantiate(audioSource);
            //audio.SetActive(false);
            audioSources.Add(audio);
        }

        foreach (SoundClip s in clips)
        {
            soundList.Add(s.id, s);
        }*/
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Play(string id)
    {
        /*for (int i = 0; i < audioSources.Count; i++)
        {
            AudioSource source = audioSources[i].GetComponent<AudioSource>();
            if (!audioSources[i].activeInHierarchy)
            {
                //AudioClip clip = Resources.Load<AudioClip>("Sounds/" + soundList[id].clip.name);
                source.clip = soundList[id].clip;
                source.loop = soundList[id].isLooping;
                source.PlayDelayed(soundList[id].delay);
                source.DOFade(1, soundList[id].fadeInDuration);
                audioSources[i].SetActive(true);
                break;
            }
        }*/
        for (int i = 0; i < audioSources.Count; i++)
        {
            AudioSource source = audioSources[i].GetComponent<AudioSource>();
            if (!source.isPlaying)
            {
                AudioClip clip = Resources.Load<AudioClip>("Sounds/" + soundList[id].clipName);
                source.PlayOneShot(clip);
                break;
            }
        }
    }

    public void Stop(string id, bool all = false)
    {
        foreach (GameObject source in audioSources)
        {
            if (source.GetComponent<AudioSource>().clip.name == soundList[id].clipName)
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

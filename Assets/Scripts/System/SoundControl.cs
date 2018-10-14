using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class SoundClip
{
    public string id = null;
    public AudioClip clip = null;
    public bool isLooping;
    public float delay;
    public float fadeInDuration;
    public float fadeOutDuration;
    public bool isFalloff = false;
    public bool isStandOut = false;
    public float spatialBlend = 0;
}

public class SoundControl : MonoBehaviour {
    public List<SoundClip> clips;
    public int pooledAudioAmount = 10;
    List<GameObject> audioSources;
    public GameObject audioSource;
    Dictionary<string, SoundClip> soundList = new Dictionary<string, SoundClip>();

    // Use this for initialization
    void Start ()
    {
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
            if (!audioSources[i].activeInHierarchy)
            {
                source.clip = soundList[id].clip;
                source.loop = soundList[id].isLooping;
                source.PlayDelayed(soundList[id].delay);
                source.DOFade(1, soundList[id].fadeInDuration);
                audioSources[i].SetActive(true);
                break;
            }
        }
    }

    public void Stop(string id, bool all = false)
    {
        foreach (GameObject source in audioSources)
        {
            if (source.GetComponent<AudioSource>().clip.name == soundList[id].clip.name)
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

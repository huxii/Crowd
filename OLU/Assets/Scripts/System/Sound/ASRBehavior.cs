using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attack, sustain, release
public class ASRBehavior : MonoBehaviour
{
    public List<string> sampleIds;
    public string endSampleId;
    public float sustainDuration = 0.5f;

    private AudioSource audioSource = null;
    private string curId = null;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sustain();
    }

    private string PickNextString()
    {
        if (sampleIds.Count == 0)
        {
            return null;
        }

        return sampleIds[Random.Range(0, sampleIds.Count)];
    }

    public void Attack()
    {
        Debug.Log("Attack");
        string nextId = PickNextString();
        audioSource = Services.soundController.PlayWithReturn(nextId);
        curId = nextId;
        timer = Time.time;
    }

    public void Sustain()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            Debug.Log("Sustain");
            if (Time.time >= timer + sustainDuration)
            {
                string nextId = PickNextString();
                Services.soundController.CrossFade(curId, nextId);
                curId = nextId;
            }

        }
    }

    public void Release()
    {
        Debug.Log("Release");
        Services.soundController.Stop(curId);
        audioSource = null;
        curId = null;
    }

    public void End()
    {
        Debug.Log("End");
        Services.soundController.Play(endSampleId);
        audioSource = null;
        curId = null;
    }
}

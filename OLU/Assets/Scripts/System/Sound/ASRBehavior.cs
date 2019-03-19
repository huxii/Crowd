using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attack, sustain, release
public class ASRBehavior : MonoBehaviour
{
    public List<string> sampleIds;
    public string startSampleId;
    public string endSampleId;
    public float sustainDuration = 0.5f;

    private AudioSource audioSource = null;
    private string curId = null;
    private float timer = 0;

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
        //Services.soundController.Play(startSampleId);

        string nextId = PickNextString();
        audioSource = Services.soundController.PlayWithReturn(nextId);

        curId = nextId;
        timer = Time.time;
    }

    public void Sustain()
    {
        if (audioSource != null)
        {
            Debug.Log("Sustain");
            if (Time.time >= timer + sustainDuration)
            {
                string nextId = PickNextString();
                Services.soundController.CrossFade(curId, nextId);

                curId = nextId;
                timer = Time.time;
            }
        }
    }

    public void Release()
    {
        Debug.Log("Release");
        if (curId != null)
        {
            Services.soundController.Stop(curId);
            audioSource = null;
            curId = null;
        }
    }

    public void End()
    {
        Debug.Log("End");
        Services.soundController.Play(endSampleId);
        audioSource = null;
        curId = null;
    }
}

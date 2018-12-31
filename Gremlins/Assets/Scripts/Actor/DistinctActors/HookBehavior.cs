using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBehavior : MonoBehaviour
{
    GameObject man = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (man == null && other.CompareTag("Man") && other.GetComponent<FloatBehavior>())
        {
            other.transform.SetParent(transform);
            other.transform.localPosition = new Vector3(0, 0, 0);
            man = other.gameObject;
        }
    }

    public void Catch()
    {
        if (man != null)
        {
            Services.gameEvents.ResetMan(man);
            man.GetComponent<FloatBehavior>().Blowing();

            // tmp
            GameObject.Find("Can").GetComponent<ObjectControl>().Activate();
        
            man = null;
        }
        else
        {
            GetComponent<ObjectControl>().Activate();
        }
    }

    public void Collect()
    {
        GetComponent<ObjectControl>().Deactivate();
    }
}

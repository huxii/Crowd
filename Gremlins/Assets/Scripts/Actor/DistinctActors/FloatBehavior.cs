using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBehavior : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> paths = new List<Vector3>();
    [SerializeField]
    private int idx = 0;

    // Use this for initialization
    void Start()
    {
        paths.Add(new Vector3(2.43f, 9.5f, -2.13f));
        paths.Add(new Vector3(-1.43f, 9.5f, -2.13f));
        paths.Add(new Vector3(2.8f, 1.5f, 0.4f));
        Blowing();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Blowing(int stage = 9999999)
    {
        if (idx > stage)
        {
            return;
        }

        if (idx < paths.Count && GetComponent<CrowdControl>().IsLocked())
        {
            Services.dotweenEvents.MoveTo(gameObject.name + " " + paths[idx].x + " " + paths[idx].y + " " + paths[idx].z + " 1 false");

            ++idx;
            if (idx >= paths.Count)
            {
                GetComponent<CrowdControl>().Unlock();
                Services.dotweenEvents.ScaleTo(gameObject.name + " 1, 1, 1, 0.5 false");
                Destroy(this);
            }
        }
    }
}
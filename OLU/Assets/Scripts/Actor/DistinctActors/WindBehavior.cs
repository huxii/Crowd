using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehavior : MonoBehaviour
{
    public List<Vector3> windBlocks;

    [SerializeField]
    private List<GameObject> insideMen = new List<GameObject>();
    [SerializeField]
    private GameObject[] windBlockOwner;

    // Use this for initialization
    void Start()
    {
        windBlockOwner = new GameObject[windBlocks.Count];
        for (int i = 0; i < windBlocks.Count; ++i)
        {
            windBlockOwner[i] = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Vector3 p in windBlocks)
        {
            Gizmos.DrawCube(p, new Vector3(0.25f, 0.25f, 0.25f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Man") && other.GetComponent<FloatBehavior>() && !insideMen.Contains(other.gameObject))
        {
            insideMen.Add(other.gameObject);
            TryBlowing();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (insideMen.Contains(other.gameObject))
        {
            insideMen.Remove(other.gameObject);
            TryBlowing();
        }
    }

    private void TryBlowing()
    {
        if (insideMen.Count != 0)
        {
            foreach (GameObject man in insideMen)
            {
                for (int i = 0; i < windBlocks.Count; ++i)
                {
                    if (windBlockOwner[i] == man)
                    {
                        break;
                    }

                    if (windBlockOwner[i] == null)
                    {
                        Services.dotweenEvents.MoveTo(man.name + " " + windBlocks[i].ToString() + " " + Vector3.Distance(man.transform.position, windBlocks[i]) / 3);
                        windBlockOwner[i] = man;
                        for (int j = i + 1; j < windBlocks.Count; ++j)
                        {
                            if (windBlockOwner[j] == man)
                            {
                                windBlockOwner[j] = null;
                            }
                        }

                        break;
                    }
                }
            }
        }
    }

    public void RemoveMan(GameObject obj)
    {
        insideMen.Remove(obj);
        for (int i = 0; i < windBlockOwner.Length; ++i)
        {
            if (windBlockOwner[i] == obj)
            {
                windBlockOwner[i] = null;
            }
        }

        TryBlowing();
    }
}

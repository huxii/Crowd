using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingManager : MonoBehaviour
{
    protected class FoundPath
    {
        //public List<GameObject> points;
        //public Vector3 endPos;
        public Crowd.Event endEvent;
        public float tol;

        public FoundPath()
        {
            endEvent = null;
            tol = 0;
        }

        public virtual void Insert(GameObject tile)
        {
        }

        public virtual void Insert(Vector3 pos)
        {
        }

        public virtual void Insert(DirectedPathEdge edge)
        {
        }
    };

    protected Dictionary<GameObject, FoundPath> pathTable = new Dictionary<GameObject, FoundPath>();
    protected FoundPath recentPath = null;

    [SerializeField]
    protected GameObject navmeshObj = null;
    [SerializeField]
    protected List<GameObject> navmeshes = new List<GameObject>();
    [SerializeField]
    [HideInInspector]
    private int navCounter = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Refresh();
    }

    private void OnDrawGizmosSelected()
    {
        Refresh();
    }

    protected void MoveUpdate()
    {
        List<GameObject> keys = new List<GameObject>(pathTable.Keys);
        foreach (GameObject actor in keys)
        {
            if (actor == null)
            {
                pathTable.Remove(actor);
            }

            ActorMoveUpdate(actor);
        }
    }

    public GameObject AddNavmesh()
    {
        if (navmeshObj == null)
        {
            navmeshObj = new GameObject();
            navmeshObj.name = "Navmeshes";
            navmeshObj.transform.SetParent(transform);
            navmeshObj.transform.localPosition = new Vector3(0, 0, 0);
            navCounter = 0;
        }

        GameObject newNavmesh = new GameObject();
        newNavmesh.name = "Navmesh" + navCounter;
        newNavmesh.transform.SetParent(navmeshObj.transform);
        newNavmesh.transform.localPosition = new Vector3(0, 0, 0);
        newNavmesh.tag = "Ground";
        newNavmesh.layer = 10;
        newNavmesh.AddComponent<BoxCollider>();
        newNavmesh.GetComponent<BoxCollider>().isTrigger = true;
        newNavmesh.AddComponent<Navmesh>();
        navmeshes.Add(newNavmesh);
        ++navCounter;

        return newNavmesh;
    }

    public void StopActor(GameObject actor)
    {
        if (pathTable.ContainsKey(actor))
        {
            pathTable.Remove(actor);
        }
    }

    protected virtual void ActorMoveUpdate(GameObject actor)
    {
    }

    public virtual void ConnectPath(GameObject p0, GameObject p1)
    {
    }

    public virtual void DisconnectPath(GameObject p0, GameObject p1)
    {
    }

    public virtual bool FindPath(GameObject actor, Vector3 endPos, float clampTol = 0.5f)
    {
        return false;
    }

    public virtual void Move(GameObject actor, float posTol, Crowd.Event endEvent = null)
    {
        if (recentPath == null)
        {
            return;
        }

        recentPath.endEvent = endEvent;
        recentPath.tol = posTol;
        if (pathTable.ContainsKey(actor))
        {
            // should abort original path
            pathTable.Remove(actor);
        }

        pathTable.Add(actor, recentPath);
        //recentPath = null;
    }

    public virtual void Refresh()
    {
        foreach (GameObject navmesh in navmeshes.ToArray())
        {
            if (navmesh == null)
            {
                navmeshes.Remove(navmesh);
            }
        }
    }
}

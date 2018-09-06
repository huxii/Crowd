using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingManager : MonoBehaviour
{
    [System.Serializable]
    public class PathEdge
    {
        public GameObject p1;
        public GameObject p2;
    };

    [SerializeField]
    private List<GameObject> pathPoints = new List<GameObject>();
    [SerializeField]
    private List<PathEdge> pathEdges = new List<PathEdge>();
    [SerializeField]
    [HideInInspector]
    private int namingCounter = 0;

    private Vector3 localSpawnPos = new Vector3(0, 0, 0);
    private float maxDistance = 100000;
    private int[] prePathPoint;
    private List<GameObject> foundPath;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject AddPathPoint()
    {
        GameObject newPathPoint = new GameObject();
        newPathPoint.name = "PathPoint" + namingCounter;
        newPathPoint.transform.SetParent(transform);
        newPathPoint.transform.localPosition = localSpawnPos;
        newPathPoint.AddComponent<PathPoint>();
        ++namingCounter;

        pathPoints.Add(newPathPoint);
        return newPathPoint.gameObject;
    }

    public void RemovePathPoint(GameObject pathPoint)
    {
    }

    public void ConnectPathPoints(GameObject p1, GameObject p2)
    {
        PathEdge edge = new PathEdge();
        edge.p1 = p1;
        edge.p2 = p2;
        pathEdges.Add(edge);
    }

    public void DisconnectPathPoints(GameObject p1, GameObject p2)
    {
        foreach (PathEdge edge in pathEdges.ToArray())
        {
            if ((edge.p1 == p1 && edge.p2 == p2) || (edge.p1 == p2 && edge.p2 == p1))
            {
                pathEdges.Remove(edge);
            }
        }
    }

    public void OnDrawGizmos()
    {
        foreach (GameObject point in pathPoints.ToArray())
        {
            if (point == null)
            {
                pathPoints.Remove(point);
            }
        }

        Gizmos.color = Color.white;
        foreach (PathEdge edge in pathEdges.ToArray())
        {
            if (edge.p1 == null || edge.p2 == null)
            {
                pathEdges.Remove(edge);
                continue;
            }
            Gizmos.DrawLine(edge.p1.transform.position, edge.p2.transform.position);
        }        
    }

    private float Distance(GameObject p1, GameObject p2)
    {
        return Vector3.Distance(p1.transform.position, p2.transform.position);
    }

    private float Distance(GameObject p, Vector3 pos)
    {
        return Vector3.Distance(p.transform.position, pos);
    }

    private GameObject FindNearestPathPoint(Vector3 pos)
    {
        float dist = -1;
        GameObject nearestPathPoint = null;
        foreach (GameObject pathPoint in pathPoints)
        {
            float tmpDist = Distance(pathPoint, pos);
            if (tmpDist < dist || dist < 0)
            {
                dist = tmpDist;
                nearestPathPoint = pathPoint;
            }
        }
        return nearestPathPoint;
    }

    private float SPFA(int N, int s, int t, float[,] path)
    {
        prePathPoint = new int[N];
        List<int> queue = new List<int>();
        float[] d = new float[N];
        bool[] inQueue = new bool[N];
        for (int i = 0; i < N; ++i)
        {
            d[i] = maxDistance;
            inQueue[i] = false;
            prePathPoint[i] = -1;
        }

        int head = 0;
        int tail = 0;
        queue.Add(s);
        inQueue[s] = true;
        d[s] = 0;
        ++tail;

        while (head < tail)
        {
            int o = queue[head];
            inQueue[o] = false;
            for (int i = 0; i < N; ++i)
            {
                if (d[i] > d[o] + path[o, i])
                {
                    d[i] = d[o] + path[o, i];
                    if (!inQueue[i])
                    {
                        queue.Add(i);
                        inQueue[i] = true;
                        ++tail;
                        prePathPoint[i] = o;
                    }
                }
            }
            ++head;
        }

        return d[t];
    }

    public bool FindPath(Vector3 startPos, Vector3 endPos)
    {
        // re-number all the pathpoints
        Dictionary<GameObject, int> IDs = new Dictionary<GameObject, int>();
        int counter = 0;
        foreach (GameObject pathPoint in pathPoints)
        {
            IDs[pathPoint] = counter;
            ++counter;
        }

        // init path matrix
        float[,] path = new float[pathPoints.Count, pathPoints.Count];
        for (int i = 0; i < counter; ++i)
        {
            for (int j = 0; j < counter; ++j)
            {
                path[i, j] = maxDistance;
            }
        }
        foreach (PathEdge pathEdge in pathEdges)
        {
            int id0 = IDs[pathEdge.p1];
            int id1 = IDs[pathEdge.p2];
            path[id0, id1] = Distance(pathEdge.p1, pathEdge.p2);
            path[id1, id0] = Distance(pathEdge.p1, pathEdge.p2);
        }

        int s = IDs[FindNearestPathPoint(startPos)];
        int t = IDs[FindNearestPathPoint(endPos)];

        if (SPFA(counter, s, t, path) >= maxDistance)
        {
            return false;
        }

        foundPath = new List<GameObject>();
        int curPoint = t;
        while (curPoint != -1)
        {
            foundPath.Insert(0, pathPoints[curPoint]);
            curPoint = prePathPoint[curPoint];
        }

        return true;
    }

    public void GoTo(GameObject actor, Vector3 startPos, Vector3 endPos)
    {
        if (FindPath(startPos, endPos))
        {
            Task preTask = null;
            for (int i = 1; i < foundPath.Count; ++i)
            {
                Task curTask = new Transport(actor, foundPath[i - 1].transform.position, foundPath[i].transform.position, Distance(foundPath[i - 1], foundPath[i]) / 3);
                if (preTask != null)
                {
                    preTask.Then(curTask);
                }
                else
                {
                    Services.taskManager.Do(curTask);
                }
                preTask = curTask;
            }
        }
    }
}

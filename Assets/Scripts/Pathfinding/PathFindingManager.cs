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
    public float pointSize = 1f;
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
            else
            {
                point.GetComponent<PathPoint>().pointSize = pointSize;
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

    private float CosAngle(Vector3 e0, Vector3 e1)
    {
        return Vector3.Dot(e0, e1) / (Vector3.Magnitude(e0) * Vector3.Magnitude(e1));
    }

    private float Distance(GameObject p1, GameObject p2)
    {
        return Vector3.Distance(p1.transform.position, p2.transform.position);
    }

    private float Distance(GameObject p, Vector3 pos)
    {
        return Vector3.Distance(p.transform.position, pos);
    }

    private float Distance(PathEdge e, Vector3 pos)
    {
        Vector3 p1p2 = e.p2.transform.position - e.p1.transform.position;
        Vector3 p1pos = pos - e.p1.transform.position;
        Vector3 p2pos = pos - e.p2.transform.position;
        float e0Cos = CosAngle(p1p2, p1pos);
        float e1Cos = CosAngle(-p1p2, p2pos);
        if (e0Cos < 0 || e1Cos < 0)
        {
            return maxDistance;
        }

        float e0Sin = Mathf.Sqrt(1 - e0Cos * e0Cos);
        return Vector3.Magnitude(p1pos) * e0Sin;
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

    private PathEdge FindNearestPathEdge(Vector3 pos)
    {
        float dist = -1;
        PathEdge nearestPathEdge = null;
        foreach (PathEdge pathEdge in pathEdges)
        {
            float tmpDist = Distance(pathEdge, pos);
            //Debug.Log(pos + " " + pathEdge.p1 + " " + pathEdge.p2 + " " + tmpDist);
            if (tmpDist < dist || dist < 0)
            {
                dist = tmpDist;
                nearestPathEdge = pathEdge;
            }
        }
        return nearestPathEdge;
    }

    public bool FindPath(Vector3 startPos, Vector3 endPos)
    {
        // re-number all the pathpoints
        Dictionary<GameObject, int> IDs = new Dictionary<GameObject, int>();
        int N = 0;
        foreach (GameObject pathPoint in pathPoints)
        {
            IDs[pathPoint] = N;
            ++N;
        }

        // init path matrix
        float[,] path = new float[pathPoints.Count, pathPoints.Count];
        for (int i = 0; i < N; ++i)
        {
            for (int j = 0; j < N; ++j)
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

        //int s = IDs[FindNearestPathPoint(startPos)];
        //int t = IDs[FindNearestPathPoint(endPos)];
        PathEdge es = FindNearestPathEdge(startPos);
        PathEdge et = FindNearestPathEdge(endPos);
        if (es == null || et == null)
        {
            return false;
        }

        float[] d = new float[N];
        for (int i = 0; i < N; ++i)
        {
            d[i] = maxDistance;
        }
        int esp0 = IDs[es.p1];
        int esp1 = IDs[es.p2];
        int etp0 = IDs[et.p1];
        int etp1 = IDs[et.p2];
        d[esp0] = Vector3.Distance(es.p1.transform.position, startPos);
        d[esp1] = Vector3.Distance(es.p2.transform.position, startPos);

        prePathPoint = new int[N];
        List<int> queue = new List<int>();
        bool[] inQueue = new bool[N];
        for (int i = 0; i < N; ++i)
        {
            inQueue[i] = false;
            prePathPoint[i] = -1;
        }

        // SPFA starts from two points
        int head = 0;
        int tail = 0;
        queue.Add(esp0);
        ++tail;
        inQueue[esp0] = true;
        queue.Add(esp1);
        ++tail;
        inQueue[esp1] = true;

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

        // two end points - choose the nearer one
        float endDis0 = d[etp0] + Vector3.Distance(et.p1.transform.position, startPos);
        float endDis1 = d[etp1] + Vector3.Distance(et.p2.transform.position, startPos);
        //Debug.Log(endDis0 + " " + endDis1);
        if (endDis0 >= maxDistance && endDis1 >= maxDistance)
        {
            return false;
        }

        foundPath = new List<GameObject>();
        int curPoint = etp0;
        if (endDis0 > endDis1)
        {
            curPoint = etp1;
        }
        while (curPoint != -1)
        {
            foundPath.Insert(0, pathPoints[curPoint]);
            curPoint = prePathPoint[curPoint];
        }

        return true;
    }

    public bool GoTo(GameObject actor, Vector3 endPos, GameObject dest = null)
    { 
        Vector3 startPos = actor.transform.position;
        //Debug.Log(startPos + "---------" + endPos);
        if (FindPath(startPos, endPos))
        {
            //Debug.Log("---------");
            Task curTask = null;
            Task preTask = new Transport(actor, startPos, foundPath[0].transform.position, Vector3.Distance(startPos, foundPath[0].transform.position) / 3);
            Services.taskManager.Do(preTask);
            for (int i = 1; i < foundPath.Count; ++i)
            {
                curTask = new Transport(actor, foundPath[i - 1].transform.position, foundPath[i].transform.position, Distance(foundPath[i - 1], foundPath[i]) / 3);
                preTask.Then(curTask);
                preTask = curTask;
            }

            curTask = new Transport(actor, foundPath[foundPath.Count - 1].transform.position, endPos, Vector3.Distance(foundPath[foundPath.Count - 1].transform.position, endPos) / 3);
            preTask.Then(curTask);

            if (dest)
            {
                curTask.Then(new FeedbackTask(new ManArrivesAtObj(actor, dest)));
            }

            return true;
        }

        return false;
    }

    //public bool GoTo(GameObject actor, Vector3 endPos)
    //{
    //    //Debug.Log(startPos + "---------" + endPos);
    //    Vector3 startPos = actor.transform.position;
    //    if (FindPath(startPos, endPos))
    //    {
    //        Task curTask = null;
    //        Task preTask = new Transport(actor, startPos, foundPath[0].transform.position, Vector3.Distance(startPos, foundPath[0].transform.position) / 3);
    //        Services.taskManager.Do(preTask);
    //        for (int i = 1; i < foundPath.Count; ++i)
    //        {
    //            curTask = new Transport(actor, foundPath[i - 1].transform.position, foundPath[i].transform.position, Distance(foundPath[i - 1], foundPath[i]) / 3);
    //            preTask.Then(curTask);
    //            preTask = curTask;
    //        }

    //        curTask = new Transport(actor, foundPath[foundPath.Count - 1].transform.position, endPos, Vector3.Distance(foundPath[foundPath.Count - 1].transform.position, endPos) / 3);
    //        preTask.Then(curTask);

    //        return true;
    //    }

    //    return false;
    //}
}

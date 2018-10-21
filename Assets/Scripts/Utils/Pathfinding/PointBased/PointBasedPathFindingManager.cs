using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBasedPathFindingManager : PathFindingManager
{
    protected class PointBasedFoundPath : FoundPath
    {
        public List<DirectedPathEdge> pathEdges;
        public bool hasStarted;

        public PointBasedFoundPath()
        {
            pathEdges = new List<DirectedPathEdge>();
            endEvent = null;
            hasStarted = false;
            tol = 0;
        }

        public override void Insert(DirectedPathEdge edge)
        {
            pathEdges.Insert(0, edge);
        }
    }

    [SerializeField]
    [HideInInspector]
    private GameObject pointsObj;
    [SerializeField]
    public float pointSize = 1f;
    [SerializeField]
    private List<GameObject> pathPoints = new List<GameObject>();
    [SerializeField]
    [HideInInspector]
    private int namingCounter = 0;

    [SerializeField]
    [HideInInspector]
    private GameObject edgesObj;
    [SerializeField]
    private List<GameObject> pathEdges = new List<GameObject>();

    private class PointToEdgeDistance
    {
        public PointToEdgeDistance(float d, bool o)
        {
            distance = d;
            isOutside = o;
        }

        public float distance;
        public bool isOutside;
    }

    private List<KeyValuePair<GameObject, GameObject>> borderTable = new List<KeyValuePair<GameObject, GameObject>>();

    private Vector3 localSpawnPos = new Vector3(0, 0, 0);
    private float maxDistance = 100000;
    private int[] prePathPoint;
    //private List<GameObject> foundPath;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
    }

    protected override void ActorMoveUpdate(GameObject actor)
    {
        base.ActorMoveUpdate(actor);

        PointBasedFoundPath path = (PointBasedFoundPath)pathTable[actor];

        if (!path.hasStarted)
        {
            Services.gameController.MoveManTo(actor, path.pathEdges[0].EndPos(), path.tol);
            path.hasStarted = true;
        }

        //if (GoToNextPoint(actor, path.pathEdges[0].EndPos(), path.speed))
        if (Vector3.Distance(actor.transform.position, path.pathEdges[0].EndPos()) <= path.tol)
        {
            if (path.pathEdges.Count <= 1)
            {
                // arrived at the final position
                if (path.endEvent != null)
                {
                    Services.eventManager.QueueEvent(path.endEvent);
                }

                pathTable.Remove(actor);
                Services.gameController.StopMan(actor);
            }
            else
            {
                // walking out of path 0
                //GameObject middlePoint = path.pathEdges[0].AcrossPoint();
                //if (middlePoint.GetComponent<PathPoint>().followObject != null && middlePoint.GetComponent<PathPoint>().isBorder)
                //{
                //    Services.gameController.ManAcrossBorder(actor, middlePoint.GetComponent<PathPoint>().followObject);
                //}

                Services.gameController.MoveManTo(actor, path.pathEdges[1].EndPos(), path.tol);
            }

            path.pathEdges.RemoveAt(0);
        }
    }

    private bool GoToNextPoint(GameObject actor, GameObject target, float speed)
    {
        return GoToNextPoint(actor, target.transform.position, speed);
    }

    private bool GoToNextPoint(GameObject actor, Vector3 targetPos, float speed)
    {
        if (Vector3.Distance(targetPos, actor.transform.position) <= speed * Time.deltaTime)
        {
            actor.transform.position = targetPos;
            return true;
        }

        Vector3 dir = (targetPos - actor.transform.position).normalized * speed * Time.deltaTime;
        actor.transform.position = actor.transform.position + dir;
        return false;
    }

    private GameObject CreateNewGameObject(string name)
    {
        GameObject newObj = new GameObject();
        newObj.name = name;
        newObj.transform.SetParent(transform);
        newObj.transform.localPosition = localSpawnPos;
        return newObj;
    }

    private void UpdateArrays()
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

        foreach (GameObject edge in pathEdges.ToArray())
        {
            if (edge == null)
            {
                pathEdges.Remove(edge);
            }
        }
    }

    public GameObject AddPathPoint()
    {
        if (pointsObj == null)
        {
            pointsObj = CreateNewGameObject("PathPoints");
        }

        GameObject newPathPoint = new GameObject();
        newPathPoint.name = "PathPoint" + namingCounter;
        newPathPoint.transform.SetParent(pointsObj.transform);
        newPathPoint.transform.localPosition = localSpawnPos;
        newPathPoint.AddComponent<PathPoint>();
        ++namingCounter;

        pathPoints.Add(newPathPoint);
        return newPathPoint.gameObject;
    }

    public void RemovePathPoint(GameObject pathPoint)
    {
        Destroy(pathPoint);
    }

    public override void ConnectPath(GameObject p0, GameObject p1)
    {
        if (edgesObj == null)
        {
            edgesObj = CreateNewGameObject("PathEdges");
        }

        GameObject newPathEdge = new GameObject();
        newPathEdge.name = "PathEdge" + p0.name + p1.name;
        newPathEdge.transform.SetParent(edgesObj.transform);
        newPathEdge.transform.localPosition = localSpawnPos;
        newPathEdge.AddComponent<PathEdge>();
        newPathEdge.GetComponent<PathEdge>().SetPoints(p0, p1);

        pathEdges.Add(newPathEdge);

        UpdateArrays();
    }

    public override void DisconnectPath(GameObject p0, GameObject p1)
    {
        foreach (GameObject edge in pathEdges.ToArray())
        {
            if ((edge.GetComponent<PathEdge>().P0() == p0 && edge.GetComponent<PathEdge>().P1() == p1) || 
                (edge.GetComponent<PathEdge>().P0() == p0 && edge.GetComponent<PathEdge>().P1() == p1))
            {
                DestroyImmediate(edge);
            }
        }

        UpdateArrays();
    }

    public void OnDrawGizmos()
    {
        UpdateArrays();       
    }

    private Vector3 Clamp(PathEdge edge, Vector3 pos)
    {
        Vector3 p00 = edge.P00();
        Vector3 p01 = edge.P01();
        Vector3 p10 = edge.P10();
        Vector3 p11 = edge.P11();

        float minx = Mathf.Min(p00.x, p01.x, p10.x, p11.x);
        float maxx = Mathf.Max(p00.x, p01.x, p10.x, p11.x);
        float miny = Mathf.Min(p00.y, p01.y, p10.y, p11.y);
        float maxy = Mathf.Max(p00.y, p01.y, p10.y, p11.y);
        float minz = Mathf.Min(p00.z, p01.z, p10.z, p11.z);
        float maxz = Mathf.Max(p00.z, p01.z, p10.z, p11.z);

        float x = Mathf.Min(maxx, Mathf.Max(minx, pos.x));
        float y = Mathf.Min(maxy, Mathf.Max(miny, pos.y));
        float z = Mathf.Min(maxz, Mathf.Max(minz, pos.z));

        return new Vector3(x, y, z);
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

    private PointToEdgeDistance Distance(PathEdge e, Vector3 pos)
    {
        Vector3 p0 = e.P0().transform.position;
        Vector3 p1 = e.P1().transform.position;

        if (e.positiveAxisExpand.magnitude > 0.01f || e.minusAxisExpand.magnitude > 0.01f)
        {
            // it's a plane
            Vector3 p2;
            if (e.positiveAxisExpand.magnitude > e.minusAxisExpand.magnitude)
            {
                p2 = p0 + e.positiveAxisExpand;
            }
            else
            {
                p2 = p0 - e.minusAxisExpand;
            }

            Plane plane = new Plane(p0, p1, p2);
            Vector3 pp = plane.ClosestPointOnPlane(pos);
            Vector3 pp0 = e.P00();
            Vector3 pp1 = e.P01();
            Vector3 pp2 = e.P11();
            Vector3 pp3 = e.P10();

            //Debug.Log(Vector3.Distance(pp, d0) + Vector3.Distance(pp, d1) + " " + Vector3.Distance(d0, d2) + Vector3.Distance(d1, d2));

            return new PointToEdgeDistance(Mathf.Abs(plane.GetDistanceToPoint(pos)),
                Vector3.Dot(Vector3.Cross(pp1 - pp0, pp - pp0), Vector3.Cross(pp3 - pp2, pp - pp2)) < 0
                || Vector3.Dot(Vector3.Cross(pp0 - pp3, pp - pp3), Vector3.Cross(pp2 - pp1, pp - pp1)) < 0);
        }
        else
        {
            // it's a line
            Vector3 p0p1 = p1 - p0;
            Vector3 p0pos = pos - p0;

            return new PointToEdgeDistance(Vector3.Cross(p0p1, p0pos).magnitude / p0p1.magnitude, Vector3.Dot(p0p1, p0pos) < 0);
        }
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

    private GameObject FindNearestPathEdge(Vector3 pos)
    {
        PointToEdgeDistance distIn = null;
        GameObject nearestPathEdgeIn = null;
        PointToEdgeDistance distOut = null;
        GameObject nearestPathEdgeOut = null;
        foreach (GameObject pathEdge in pathEdges)
        {
            // will pick the edge whose zone covers the point, but distance should not be too long
            PointToEdgeDistance tmpDist = Distance(pathEdge.GetComponent<PathEdge>(), pos);
            if (!tmpDist.isOutside)
            {
                if (distIn == null || distIn.distance > tmpDist.distance)
                {
                    distIn = tmpDist;
                    nearestPathEdgeIn = pathEdge;
                }
            }
            else
            {
                if (distOut == null || distOut.distance > tmpDist.distance)
                {
                    distOut = tmpDist;
                    nearestPathEdgeOut = pathEdge;
                }
            }

            //Debug.Log(pos + " " + pathEdge + " " + tmpDist.distance + " " + tmpDist.isOutside);
        }

        if (distIn != null /*&& distIn.distance < 0.15f*/)
        {
            return nearestPathEdgeIn;
        }
        else
        {
            return nearestPathEdgeOut;
        }
    }

    private bool FindPath(Vector3 startPos, Vector3 endPos, float clampTol)
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
        foreach (GameObject pathEdge in pathEdges)
        {
            GameObject p0 = pathEdge.GetComponent<PathEdge>().P0();
            GameObject p1 = pathEdge.GetComponent<PathEdge>().P1();

            int id0 = IDs[p0];
            int id1 = IDs[p1];
            path[id0, id1] = Distance(p0, p1);
            path[id1, id0] = path[id0, id1];
        }

        //int s = IDs[FindNearestPathPoint(startPos)];
        //int t = IDs[FindNearestPathPoint(endPos)];
        GameObject es = FindNearestPathEdge(startPos);
        GameObject et = FindNearestPathEdge(endPos);
        Debug.Log(es + " " + et);
        if (es == null || et == null)
        {
            return false;
        }

        // move in the same "zone"
        if (es == et)
        {
            //Debug.Log("same");
            recentPath = new FoundPath();
            Vector3 validEndPos = Clamp(et.GetComponent<PathEdge>(), endPos);
            if (Vector3.Distance(validEndPos, endPos) > clampTol)
            {
                return false;
            }
            recentPath.Insert(new DirectedPathEdgeOnPositions(startPos, validEndPos));
        }
        else
        {

            float[] d = new float[N];
            for (int i = 0; i < N; ++i)
            {
                d[i] = maxDistance;
            }
            int esp0 = IDs[es.GetComponent<PathEdge>().P0()];
            int esp1 = IDs[es.GetComponent<PathEdge>().P1()];
            int etp0 = IDs[et.GetComponent<PathEdge>().P0()];
            int etp1 = IDs[et.GetComponent<PathEdge>().P1()];
            d[esp0] = Vector3.Distance(es.GetComponent<PathEdge>().P0().transform.position, startPos);
            d[esp1] = Vector3.Distance(es.GetComponent<PathEdge>().P1().transform.position, startPos);
            //d[s] = 0;

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
            //queue.Add(s);
            //++tail;
            //inQueue[s] = true;

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
            float endDis0 = d[etp0] + Vector3.Distance(et.GetComponent<PathEdge>().P0().transform.position, endPos);
            float endDis1 = d[etp1] + Vector3.Distance(et.GetComponent<PathEdge>().P1().transform.position, endPos);
            //Debug.Log(endDis0 + " " + endDis1);
            if (endDis0 >= maxDistance && endDis1 >= maxDistance)
            {
                return false;
            }

            // construct result path
            recentPath = new PointBasedFoundPath();
            int curPoint = etp0;
            if (endDis0 > endDis1)
            {
                curPoint = etp1;
            }

            Vector3 validEndPos = Clamp(et.GetComponent<PathEdge>(), endPos);
            if (Vector3.Distance(validEndPos, endPos) > clampTol)
            {
                return false;
            }

            recentPath.Insert(new DirectedPathEdgeOnObjectAndPosition(pathPoints[curPoint], validEndPos));

            while (true)
            {
                int prePoint = prePathPoint[curPoint];
                if (prePoint != -1)
                {
                    recentPath.Insert(new DirectedPathEdgeOnTwoObjects(pathPoints[prePoint], pathPoints[curPoint]));
                }
                else
                {
                    break;
                }
                curPoint = prePathPoint[curPoint];
            }
            recentPath.Insert(new DirectedPathEdgeOnPositionAndObject(startPos, pathPoints[curPoint]));
        }

        return true;
    }

    public override bool FindPath(GameObject actor, Vector3 endPos, float clampTol = 0.5f)
    {
        recentPath = null;
        Vector3 startPos = actor.transform.position;
        //Debug.Log(startPos + "---------" + endPos);
        return FindPath(startPos, endPos, clampTol);
    }

    public override void Move(GameObject actor, float posTol, Crowd.Event endEvent = null)
    {
        base.Move(actor, posTol, endEvent);
    }
}

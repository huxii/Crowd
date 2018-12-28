using System.Collections;
using System.Collections.Generic;
using Crowd;
using UnityEngine;

public class TileBasedPathFindingManager : PathFindingManager
{
    protected abstract class PathUnit
    {
        public TileEdge.MovementType pathType;

        public virtual Vector3 Position()
        {
            return Vector3.zero;
        }
    }

    protected class TilePathUnit : PathUnit
    {
        public GameObject tile;

        public TilePathUnit(GameObject p, TileEdge.MovementType t)
        {
            tile = p;
            pathType = t;
        }

        public override Vector3 Position()
        {
            return tile.transform.position;
        }
    }

    protected class PosPathUnit : PathUnit
    {
        public Vector3 pos;

        public PosPathUnit(Vector3 p, TileEdge.MovementType t)
        {
            pos = p;
            pathType = t;
        }

        public override Vector3 Position()
        {
            return pos;
        }
    }

    protected class TileBasedFoundPath : FoundPath
    {
        public List<PathUnit> paths;

        private List<Vector3> axises;

        public TileBasedFoundPath()
        {
            paths = new List<PathUnit>();
            //pathTypes = new List<TileEdge.MovementType>();
            endEvent = null;
            tol = 0;

            axises = new List<Vector3>();
            axises.Add(Vector3.right);
            axises.Add(Vector3.left);
            axises.Add(Vector3.up);
            axises.Add(Vector3.down);
            axises.Add(Vector3.forward);
            axises.Add(Vector3.back);
        }

        public override void InsertAtHead(Vector3 pos, TileEdge.MovementType type = TileEdge.MovementType.WALK)
        {
            PosPathUnit t = new PosPathUnit(pos, type);
            paths.Insert(0, t);
        }

        public override void InsertAtHead(GameObject obj, TileEdge.MovementType type = TileEdge.MovementType.WALK)
        {
            TilePathUnit t = new TilePathUnit(obj, type);
            paths.Insert(0, t);
        }

        //public override Vector3 LastUnitPos()
        //{
        //    if (paths.Count <= 1)
        //    {
        //        Debug.Log("Should never happen.");
        //        return new Vector3(0, 0, 0);
        //    }

        //    return paths[paths.Count - 2];
        //}

        //public override Vector3 LastUnitOrientation(Vector3 actorPos)
        //{
        //    if (paths.Count <= 1)
        //    {
        //        Debug.Log("Again, should never happen.");
        //        return new Vector3(0, 0, 0);
        //    }

        //    Vector3 dir;
        //    if (paths.Count == 2)
        //    {
        //        dir = paths[paths.Count - 2] - actorPos;
        //    }
        //    else
        //    {
        //        dir = paths[paths.Count - 2] - paths[paths.Count - 3];
        //    }

        //    float maxDot = -1;
        //    Vector3 closestAxis = new Vector3(0, 0, 0);
        //    foreach (Vector3 axis in axises)
        //    {
        //        float dot = Vector3.Dot(dir.normalized, axis);
        //        if (dot > maxDot)
        //        {
        //            maxDot = dot;
        //            closestAxis = axis;
        //        }
        //    }

        //    return closestAxis;
        //}
    }

    [SerializeField]
    private GameObject tilesObj = null;
    [SerializeField]
    private List<GameObject> tiles = new List<GameObject>();
    [SerializeField]
    private GameObject edgesObj = null;
    [SerializeField]
    private List<GameObject> tileEdges = new List<GameObject>();
    [HideInInspector]
    [SerializeField]
    private int tileCounter = 0;

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

        TileBasedFoundPath path = (TileBasedFoundPath)pathTable[actor];

        //if (GoToNextPoint(actor, path.pathEdges[0].EndPos(), path.speed))
        if (Vector3.Distance(actor.transform.position, path.paths[0].Position()) <= path.tol)
        {
            if (path.paths.Count <= 1)
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
                Services.gameController.SetManTargetPosition(actor, path.paths[1].Position(), path.tol, path.paths[1].pathType);
                path.paths.RemoveAt(0);
            }
        }
    }

    public GameObject AddTile()
    {
        if (tilesObj == null)
        {
            tilesObj = new GameObject();
            tilesObj.name = "Tiles";
            tilesObj.transform.SetParent(transform);
            tilesObj.transform.localPosition = new Vector3(0, 0, 0);
            tileCounter = 0;
        }

        GameObject newTile = new GameObject();
        newTile.name = "Tile" + tileCounter;
        newTile.transform.SetParent(tilesObj.transform);
        newTile.transform.localPosition = new Vector3(0, 0, 0);
        newTile.layer = 2;
        newTile.AddComponent<BoxCollider>();
        newTile.GetComponent<BoxCollider>().isTrigger = true;
        newTile.AddComponent<Tile>();
        tiles.Add(newTile);
        ++tileCounter;

        return newTile;
    }

    public override void EnableUnit(GameObject p)
    {
        p.GetComponent<Tile>().enabled = true;
    }

    public override void DisableUnit(GameObject p)
    {
        p.GetComponent<Tile>().enabled = false;
    }

    public override void ConnectPath(GameObject p0, GameObject p1)
    {
        if (edgesObj == null)
        {
            edgesObj = new GameObject();
            edgesObj.name = "Edges";
            edgesObj.transform.SetParent(transform);
            edgesObj.transform.localPosition = new Vector3(0, 0, 0);
        }

        foreach (GameObject edge in tileEdges)
        {
            if ((edge.GetComponent<TileEdge>().t0 == p0 && edge.GetComponent<TileEdge>().t1 == p1)
                || (edge.GetComponent<TileEdge>().t0 == p1 && edge.GetComponent<TileEdge>().t1 == p0))
            {
                return;
            }
        }

        GameObject newTileEdge = new GameObject();
        newTileEdge.name = "TileEdge" + p0.name + p1.name;
        newTileEdge.transform.SetParent(edgesObj.transform);
        newTileEdge.transform.localPosition = new Vector3(0, 0, 0);
        newTileEdge.AddComponent<TileEdge>();
        newTileEdge.GetComponent<TileEdge>().t0 = p0;
        newTileEdge.GetComponent<TileEdge>().t1 = p1;

        tileEdges.Add(newTileEdge);
    }

    public override void DisconnectPath(GameObject p0, GameObject p1)
    {
        foreach (GameObject edge in tileEdges.ToArray())
        {
            if ((edge.GetComponent<TileEdge>().t0 == p0 && edge.GetComponent<TileEdge>().t1 == p1)
                || (edge.GetComponent<TileEdge>().t0 == p1 && edge.GetComponent<TileEdge>().t1 == p0))
            {
                tileEdges.Remove(edge);
                DestroyImmediate(edge);
            }
        }
    }

    private GameObject FindNearestTile(Vector3 pos)
    {
        float dist = float.MaxValue;
        GameObject nearestTile = null;
        foreach (GameObject tile in tiles)
        {
            if (tile.GetComponent<Tile>().enabled)
            {
                if (tile.name == "Tile7" || tile.name == "Tile8")
                {
                    Debug.Log(pos + " " + tile.name + " " + tile.transform.position + " " + Vector3.Distance(pos, tile.transform.position));
                }
                if (Vector3.Distance(pos, tile.transform.position) < dist)
                {
                    dist = Vector3.Distance(pos, tile.transform.position);
                    nearestTile = tile;
                }
            }
        }

        if (dist < 3f)
        {
            return nearestTile;
        }
        else
        {
            return null;
        }
    }

    public override bool FindPath(GameObject actor, Vector3 endPos, float clampTol = 0.5F)
    {
        recentPath = new TileBasedFoundPath();

        Vector3 startPos = actor.transform.position;
        GameObject startTile = FindNearestTile(startPos);
        GameObject endTile = FindNearestTile(endPos);
        if (startTile == null || endTile == null)
        {
            return false;
        }

        recentPath.endUnit = endTile;

        // re-number all the pathpoints
        Dictionary<GameObject, int> IDs = new Dictionary<GameObject, int>();
        int N = 0;
        foreach (GameObject tile in tiles)
        {
            if (!IDs.ContainsKey(tile))
            {
                IDs.Add(tile, N);
                ++N;
            }
        }

        // init path matrix
        float[,] path = new float[tiles.Count, tiles.Count];
        TileEdge.MovementType[,] pathTypes = new TileEdge.MovementType[tiles.Count, tiles.Count];
        for (int i = 0; i < N; ++i)
        {
            for (int j = 0; j < N; ++j)
            {
                path[i, j] = float.MaxValue;
            }
        }
        foreach (GameObject edge in tileEdges)
        {
            GameObject p0 = edge.GetComponent<TileEdge>().t0;
            GameObject p1 = edge.GetComponent<TileEdge>().t1;
            if (p0.GetComponent<Tile>().enabled && p1.GetComponent<Tile>().enabled)
            {
                int id0 = IDs[p0];
                int id1 = IDs[p1];
                path[id0, id1] = path[id1, id0] = Vector3.Distance(p0.transform.position, p1.transform.position);
                pathTypes[id0, id1] = pathTypes[id1, id0] = edge.GetComponent<TileEdge>().type;
            }
            //Debug.Log(p0 + " " + p1 + " " + id0 + " " + id1 + " " + edge.GetComponent<TileEdge>().type);
        }

        float[] d = new float[N];
        int[] preTile = new int[N];
        List<int> queue = new List<int>();
        bool[] inQueue = new bool[N];
        for (int i = 0; i < N; ++i)
        {
            inQueue[i] = false;
            preTile[i] = -1;
            d[i] = float.MaxValue;
        }

        int startID = IDs[startTile];
        int endID = IDs[endTile];

        int head = 0;
        int tail = 0;
        queue.Add(startID);
        inQueue[startID] = true;
        ++tail;
        d[startID] = 0;
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
                        preTile[i] = o;
                    }
                }
            }
            ++head;
        }

        if (d[endID] >= float.MaxValue)
        {
            return false;
        }

        int curTile = endID;
        recentPath.InsertAtHead(endPos);
        while (curTile != -1)
        {
            if (preTile[curTile] == -1)
            {
                recentPath.InsertAtHead(tiles[curTile]);
            }
            else
            {
                //Debug.Log(curTile + " " + preTile[curTile] + " " + pathTypes[curTile, preTile[curTile]]);
                recentPath.InsertAtHead(tiles[curTile], pathTypes[curTile, preTile[curTile]]);
            }
            curTile = preTile[curTile];
        }
        recentPath.InsertAtHead(startPos);
        recentPath.isComplete = true;

        return true;
    }

    public override void Move(GameObject actor, float posTol, Crowd.Event endEvent)
    {
        base.Move(actor, posTol, endEvent);
        //Debug.Log(actor.gameObject.name + " " + ((TileBasedFoundPath)recentPath).paths.Count);
        var manArrivedEvent = endEvent as ManArrives;
        if (manArrivedEvent.obj == null)
        {
            ((TileBasedFoundPath)recentPath).paths.RemoveAt(((TileBasedFoundPath)recentPath).paths.Count - 1);
        }

        //Debug.Log(actor.gameObject.name + " " + ((TileBasedFoundPath)recentPath).paths.Count);
    }

    public override void Refresh()
    {
        base.Refresh();

        foreach (GameObject tile in tiles.ToArray())
        {
            if (tile == null)
            {
                tiles.Remove(tile);
            }
        }

        foreach (GameObject edge in tileEdges.ToArray())
        {
            if (edge == null || edge.GetComponent<TileEdge>().t0 == null || edge.GetComponent<TileEdge>().t1 == null)
            {
                tileEdges.Remove(edge);
            }
        }
    }
}

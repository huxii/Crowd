using System.Collections;
using System.Collections.Generic;
using Crowd;
using UnityEngine;

public class TileBasedPathFindingManager : PathFindingManager
{
    protected class TileBasedFoundPath : FoundPath
    {
        public List<Vector3> paths;

        public TileBasedFoundPath()
        {
            paths = new List<Vector3>();
            endEvent = null;
            tol = 0;
        }

        public override void Insert(Vector3 pos)
        {
            paths.Insert(0, pos);
        }
    }

    [SerializeField]
    private GameObject tilesObj = null;
    [SerializeField]
    private GameObject edgesObj = null;

    [SerializeField]
    private List<GameObject> tiles = new List<GameObject>();
    [SerializeField]
    private List<GameObject> tileEdges = new List<GameObject>();
    [HideInInspector]
    [SerializeField]
    private int counter = 0;

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
        if (Vector3.Distance(actor.transform.position, path.paths[0]) <= path.tol)
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
                Services.gameController.MoveManTo(actor, path.paths[1], path.tol);

                //// walking out of path 0
                //GameObject middlePoint = path.pathEdges[0].AcrossPoint();
                //if (middlePoint.GetComponent<PathPoint>().followObject != null && middlePoint.GetComponent<PathPoint>().isBorder)
                //{
                //    Services.gameController.ManAcrossBorder(actor, middlePoint.GetComponent<PathPoint>().followObject);
                //}

                //Services.gameController.MoveManTo(actor, path.pathEdges[1].EndPos(), path.tol);
            }

            path.paths.RemoveAt(0);
        }
    }

    private void UpdateArrays()
    {
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

    public GameObject AddTile()
    {
        if (tilesObj == null)
        {
            tilesObj = new GameObject();
            tilesObj.name = "Tiles";
            tilesObj.transform.SetParent(transform);
            tilesObj.transform.localPosition = new Vector3(0, 0, 0);
            counter = 0;
        }

        GameObject newTile = new GameObject();
        newTile.name = "Tile" + counter;
        newTile.transform.SetParent(tilesObj.transform);
        newTile.transform.localPosition = new Vector3(0, 0, 0);
        newTile.layer = 2;
        newTile.AddComponent<BoxCollider>();
        newTile.GetComponent<BoxCollider>().isTrigger = true;
        newTile.AddComponent<Tile>();
        tiles.Add(newTile);
        ++counter;

        return newTile;
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

    private GameObject FindNearestTile(Vector3 pos)
    {
        float dist = float.MaxValue;
        GameObject nearestTile = null;
        foreach (GameObject tile in tiles)
        {
            if (Vector3.Distance(pos, tile.transform.position) < dist)
            {
                dist = Vector3.Distance(pos, tile.transform.position);
                nearestTile = tile;
            }
        }

        if (dist < 1.5f)
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
        recentPath = null;

        Vector3 startPos = actor.transform.position;
        GameObject startTile = FindNearestTile(startPos);
        GameObject endTile = FindNearestTile(endPos);
        if (startTile == null || endTile == null)
        {
            return false;
        }
        //Debug.Log(startTile + " " + endTile);

        // re-number all the pathpoints
        Dictionary<GameObject, int> IDs = new Dictionary<GameObject, int>();
        int N = 0;
        foreach (GameObject tile in tiles)
        {
            IDs[tile] = N;
            ++N;
        }

        // init path matrix
        float[,] path = new float[tiles.Count, tiles.Count];
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

            int id0 = IDs[p0];
            int id1 = IDs[p1];
            path[id0, id1] = path[id1, id0] = Vector3.Distance(p0.transform.position, p1.transform.position);
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

        recentPath = new TileBasedFoundPath();

        int curTile = endID;
        recentPath.Insert(endPos);
        while (curTile != -1)
        {
            recentPath.Insert(tiles[curTile].transform.position);
            curTile = preTile[curTile];
        }
        recentPath.Insert(startPos);

        return true;
    }

    public override void Move(GameObject actor, float posTol, Crowd.Event endEvent = null)
    {
        base.Move(actor, posTol, endEvent);

        if (endEvent == null)
        {
            ((TileBasedFoundPath)recentPath).paths.RemoveAt(((TileBasedFoundPath)recentPath).paths.Count - 1);
        }
    }

    public override void Refresh()
    {
        base.Refresh();

        UpdateArrays();
    }
}

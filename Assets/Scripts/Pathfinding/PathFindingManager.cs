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
    private Vector3 localSpawnPos = new Vector3(0, 0, 0);

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
        newPathPoint.name = "PathPoint";
        newPathPoint.transform.SetParent(transform);
        newPathPoint.transform.localPosition = localSpawnPos;
        newPathPoint.AddComponent<PathPoint>();

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
}

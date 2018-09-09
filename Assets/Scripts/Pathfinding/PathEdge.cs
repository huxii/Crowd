using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEdge : MonoBehaviour
{
    public Vector3 axisOffset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual Vector3 StartPos()
    {
        return new Vector3(0, 0, 0);
    }

    public virtual Vector3 EndPos()
    {
        return new Vector3(0, 0, 0);
    }
}

public class PathEdgeOnTwoObjects : PathEdge
{
    [SerializeField]
    private GameObject p0;
    [SerializeField]
    private GameObject p1;

    public PathEdgeOnTwoObjects(GameObject point0, GameObject point1)
    {
        p0 = point0;
        p1 = point1;
    }

    public void SetPoints(GameObject point0, GameObject point1)
    {
        p0 = point0;
        p1 = point1;
    }

    private void DrawEdge(Color color)
    {
        if (p0 == null || p1 == null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Gizmos.color = color;
        Gizmos.DrawLine(p0.transform.position, p1.transform.position);

        Vector3 p00 = p0.transform.position - axisOffset;
        Vector3 p01 = p0.transform.position + axisOffset;
        Vector3 p10 = p1.transform.position - axisOffset;
        Vector3 p11 = p1.transform.position + axisOffset;
        Gizmos.DrawLine(p00, p10);
        Gizmos.DrawLine(p01, p11);
        Gizmos.DrawLine(p00, p01);
        Gizmos.DrawLine(p10, p11);
    }

    private void OnDrawGizmos()
    {
        DrawEdge(Color.white);
    }

    private void OnDrawGizmosSelected()
    {
        DrawEdge(Color.red);
    }

    public GameObject P0()
    {
        return p0;
    }

    public GameObject P1()
    {
        return p1;
    }

    public override Vector3 StartPos()
    {
        return p0.transform.position;
    }

    public override Vector3 EndPos()
    {
        return p1.transform.position;
    }
}

public class PathEdgeOnObjectAndPosition : PathEdge
{
    [SerializeField]
    private GameObject p0;
    [SerializeField]
    private Vector3 p1pos;

    public PathEdgeOnObjectAndPosition(GameObject point0, Vector3 point1pos)
    {
        p0 = point0;
        p1pos = point1pos;
    }

    public override Vector3 StartPos()
    {
        return p0.transform.position;
    }

    public override Vector3 EndPos()
    {
        return p1pos;
    }
}

public class PathEdgeOnPositionAndObject : PathEdge
{
    [SerializeField]
    private Vector3 p0pos;
    [SerializeField]
    private GameObject p1;

    public PathEdgeOnPositionAndObject(Vector3 point0pos, GameObject point1)
    {
        p0pos = point0pos;
        p1 = point1;
    }

    public override Vector3 StartPos()
    {
        return p0pos;
    }

    public override Vector3 EndPos()
    {
        return p1.transform.position;
    }
}

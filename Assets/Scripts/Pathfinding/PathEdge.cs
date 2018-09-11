using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEdge : MonoBehaviour
{
    // to indicate the "zone" of the edge
    public Vector3 minusAxisExpand;
    public Vector3 positiveAxisExpand;

    [SerializeField]
    private GameObject p0;
    [SerializeField]
    private GameObject p1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

        Vector3 p00 = p0.transform.position - minusAxisExpand;
        Vector3 p01 = p0.transform.position + positiveAxisExpand;
        Vector3 p10 = p1.transform.position - minusAxisExpand;
        Vector3 p11 = p1.transform.position + positiveAxisExpand;
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

    public void SetPoints(GameObject point0, GameObject point1)
    {
        p0 = point0;
        p1 = point1;
    }

    public GameObject P0()
    {
        return p0;
    }

    public GameObject P1()
    {
        return p1;
    }
}

public class DirectedPathEdge
{
    // to indicate the "zone" of the edge
    public Vector3 axisOffset;

    public virtual Vector3 StartPos()
    {
        return new Vector3(0, 0, 0);
    }

    public virtual Vector3 EndPos()
    {
        return new Vector3(0, 0, 0);
    }

    public virtual GameObject LockedObject()
    {
        return null;
    }

    public virtual void Lock()
    {
    }

    public virtual void Unlock()
    {
    }
}

public class DirectedPathEdgeOnTwoObjects : DirectedPathEdge
{
    private GameObject p0;
    private GameObject p1;

    public DirectedPathEdgeOnTwoObjects(GameObject point0, GameObject point1)
    {
        p0 = point0;
        p1 = point1;
    }

    public override Vector3 StartPos()
    {
        return p0.transform.position;
    }

    public override Vector3 EndPos()
    {
        return p1.transform.position;
    }

    public override void Lock()
    {
        if (p0.GetComponent<PathPoint>().followObject)
        {
            p0.GetComponent<PathPoint>().followObject.GetComponent<ObjectControl>().Lock();
        }
    }

    public override void Unlock()
    {
        if (p0.GetComponent<PathPoint>().followObject)
        {
            p0.GetComponent<PathPoint>().followObject.GetComponent<ObjectControl>().Unlock();
        }
    }
}

public class DirectedPathEdgeOnObjectAndPosition : DirectedPathEdge
{
    private GameObject p0;
    private Vector3 p1pos;

    public DirectedPathEdgeOnObjectAndPosition(GameObject point0, Vector3 point1pos)
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

    public override void Lock()
    {
        if (p0.GetComponent<PathPoint>().followObject)
        {
            p0.GetComponent<PathPoint>().followObject.GetComponent<ObjectControl>().Lock();
        }
    }

    public override void Unlock()
    {
        if (p0.GetComponent<PathPoint>().followObject)
        {
            p0.GetComponent<PathPoint>().followObject.GetComponent<ObjectControl>().Unlock();
        }
    }
}

public class DirectedPathEdgeOnPositionAndObject : DirectedPathEdge
{
    private Vector3 p0pos;
    private GameObject p1;

    public DirectedPathEdgeOnPositionAndObject(Vector3 point0pos, GameObject point1)
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

public class DirectedPathEdgeOnPositions : DirectedPathEdge
{
    private Vector3 p0pos;
    private Vector3 p1pos;

    public DirectedPathEdgeOnPositions(Vector3 point0pos, Vector3 point1pos)
    {
        p0pos = point0pos;
        p1pos = point1pos;
    }

    public override Vector3 StartPos()
    {
        return p0pos;
    }

    public override Vector3 EndPos()
    {
        return p1pos;
    }
}

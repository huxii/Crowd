using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEdge : MonoBehaviour
{
    public enum Orientation
    {
        EDGE,
        X,
        Y,
        Z
    };

    public Orientation axis = Orientation.EDGE;

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

        Vector3 p00 = P00();
        Vector3 p01 = P01();
        Vector3 p10 = P10();
        Vector3 p11 = P11();
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

    public Vector3 P00()
    {
        Vector3 middle = (p0.transform.position + p1.transform.position) / 2;
        switch (axis)
        {
            case Orientation.EDGE:
                return p0.transform.position - minusAxisExpand;
            case Orientation.X:
                return new Vector3(p0.transform.position.x, middle.y, middle.z) - minusAxisExpand;
            case Orientation.Y:
                return new Vector3(middle.x, p0.transform.position.y, middle.z) - minusAxisExpand;
            case Orientation.Z:
                return new Vector3(middle.x, middle.y, p0.transform.position.z) - minusAxisExpand;
        }

        return p0.transform.position - minusAxisExpand;
    }

    public Vector3 P01()
    {
        Vector3 middle = (p0.transform.position + p1.transform.position) / 2;
        switch (axis)
        {
            case Orientation.EDGE:
                return p0.transform.position + positiveAxisExpand;
            case Orientation.X:
                return new Vector3(p0.transform.position.x, middle.y, middle.z) + positiveAxisExpand;
            case Orientation.Y:
                return new Vector3(middle.x, p0.transform.position.y, middle.z) + positiveAxisExpand;
            case Orientation.Z:
                return new Vector3(middle.x, middle.y, p0.transform.position.z) + positiveAxisExpand;
        }

        return p0.transform.position + positiveAxisExpand;
    }

    public Vector3 P10()
    {
        Vector3 middle = (p0.transform.position + p1.transform.position) / 2;
        switch (axis)
        {
            case Orientation.EDGE:
                return p1.transform.position - minusAxisExpand;
            case Orientation.X:
                return new Vector3(p1.transform.position.x, middle.y, middle.z) - minusAxisExpand;
            case Orientation.Y:
                return new Vector3(middle.x, p1.transform.position.y, middle.z) - minusAxisExpand;
            case Orientation.Z:
                return new Vector3(middle.x, middle.y, p1.transform.position.z) - minusAxisExpand;
        }

        return p1.transform.position - minusAxisExpand;
    }

    public Vector3 P11()
    {
        Vector3 middle = (p0.transform.position + p1.transform.position) / 2;
        switch (axis)
        {
            case Orientation.EDGE:
                return p1.transform.position + positiveAxisExpand;
            case Orientation.X:
                return new Vector3(p1.transform.position.x, middle.y, middle.z) + positiveAxisExpand;
            case Orientation.Y:
                return new Vector3(middle.x, p1.transform.position.y, middle.z) + positiveAxisExpand;
            case Orientation.Z:
                return new Vector3(middle.x, middle.y, p1.transform.position.z) + positiveAxisExpand;
        }

        return p1.transform.position + positiveAxisExpand;
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

    public virtual GameObject AcrossPoint()
    {
        return null;
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

    public override GameObject AcrossPoint()
    {
        return p1;
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

    public override GameObject AcrossPoint()
    {
        return p1;
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

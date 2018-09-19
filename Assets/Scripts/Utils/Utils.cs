using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    int[] union;

    private int FindUnion(int x)
    {
        if (union[x] == x)
        {
            return x;
        }
        union[x] = FindUnion(union[x]);
        return union[x];
    }

    private void Union(int x, int y)
    {
        int ux = FindUnion(x);
        int uy = FindUnion(y);
        if (ux != uy)
        {
            union[x] = y;
        }
    }

    public void RecalculateNormals()
    {
        GameObject[] objs = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
        foreach (GameObject obj in objs)
        {
            if (obj.GetComponent<MeshFilter>())
            {
                Mesh mesh = obj.GetComponent<MeshFilter>().sharedMesh;
                Vector3[] verts = mesh.vertices;
                int[] tris = mesh.triangles;
                Color[] unionColors = new Color[verts.Length];
                Color[] colors = new Color[verts.Length];

                union = new int[verts.Length];
                for (int i = 0; i < verts.Length; ++i)
                {
                    union[i] = i;
                    unionColors[i] = new Color(0, 0, 0, 0);
                    for (int j = 0; j < i; ++j)
                    {
                        if (Vector3.Distance(verts[i], verts[j]) < 0.001)
                        {
                            Union(i, j);
                        }
                    }
                }

                for (int i = 0; i < tris.Length; i += 3)
                {
                    int v0 = tris[i];
                    int v1 = tris[i + 1];
                    int v2 = tris[i + 2];
                    //Vector3 p0 = verts[v0];
                    //Vector3 p1 = verts[v1];
                    //Vector3 p2 = verts[v2];
                    Vector3 p0 = obj.transform.TransformPoint(verts[v0]);
                    Vector3 p1 = obj.transform.TransformPoint(verts[v1]);
                    Vector3 p2 = obj.transform.TransformPoint(verts[v2]);
                    Vector3 p0p1 = p1 - p0;
                    Vector3 p0p2 = p2 - p0;
                    Vector3 normal = Vector3.Cross(p0p1, p0p2);
                    float a0 = Vector3.Angle(p1 - p0, p2 - p0);
                    float a1 = Vector3.Angle(p2 - p1, p0 - p1);
                    float a2 = Vector3.Angle(p1 - p2, p0 - p2);
                    normal /= normal.magnitude;
                    unionColors[FindUnion(v0)] += a0 * new Color(normal.x, normal.y, normal.z, 0);
                    unionColors[FindUnion(v1)] += a1 * new Color(normal.x, normal.y, normal.z, 0);
                    unionColors[FindUnion(v2)] += a2 * new Color(normal.x, normal.y, normal.z, 0);
                    //normal /= normal.magnitude;
                    //unionColors[FindUnion(v0)] += new Color(normal.x, normal.y, normal.z, 0);
                    //unionColors[FindUnion(v1)] += new Color(normal.x, normal.y, normal.z, 0);
                    //unionColors[FindUnion(v2)] += new Color(normal.x, normal.y, normal.z, 0);
                }

                for (int i = 0; i < verts.Length; ++i)
                {
                    colors[i] = Vector4.Normalize(unionColors[FindUnion(i)]);
                }

                mesh.colors = colors;
            }
        }
    }
}

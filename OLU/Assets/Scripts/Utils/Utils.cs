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
        GameObject interactables = GameObject.Find("Interactables");
        if (interactables == null)
        {
            return;
        }

        MeshFilter[] meshFilters = interactables.GetComponentsInChildren<MeshFilter>();
        if (meshFilters == null)
        {
            return;
        }

        foreach (MeshFilter meshFilter in meshFilters)
        {
            Mesh mesh = meshFilter.sharedMesh;
            if (mesh == null)
            {
                continue;
            }
            //if (mat.GetFloat("_OutlineWidth") <= 0)
            //{
            //    continue;
            //}

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
                Vector3 p0 = verts[v0];
                Vector3 p1 = verts[v1];
                Vector3 p2 = verts[v2];
                //Vector3 p0 = obj.transform.TransformPoint(verts[v0]);
                //Vector3 p1 = obj.transform.TransformPoint(verts[v1]);
                //Vector3 p2 = obj.transform.TransformPoint(verts[v2]);
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
            }

            for (int i = 0; i < verts.Length; ++i)
            {
                colors[i] = Vector4.Normalize(unionColors[FindUnion(i)]);
            }

            mesh.colors = colors;
        }
    }

    public float Clamp360(float angle)
    {
        int loop = (int)Mathf.Abs(angle / 360f);

        if (angle < 0)
        {
            angle += 360f * (loop + 1);
        }
        else
        {
            angle -= 360f * loop;
        }

        return angle;
    }

    public float LerpRotation(float curValue, float targetValue, float speed)
    {
        float realTargetValue = Clamp360(targetValue);
        float retValue = curValue;

        if (Mathf.Abs(realTargetValue - curValue) < 0.001f)
        {
            retValue = realTargetValue;
        }
        else
        if (Mathf.Abs(realTargetValue - curValue) > 180)
        {
            if (realTargetValue > curValue)
            {
                retValue = curValue - (curValue - realTargetValue + 360f) * Time.deltaTime * speed;
                if (retValue < 0.01f)
                {
                    retValue = 360f;
                }
            }
            else
            {
                retValue = curValue + (360 - curValue + realTargetValue) * Time.deltaTime * speed;
                if (retValue > 359.99f)
                {
                    retValue = 0f;
                }
            }
        }
        else
        {
            retValue = Mathf.Lerp(curValue, realTargetValue, Time.deltaTime * speed);
        }
        return retValue;
    }

    public void CheckPlatform()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                Application.targetFrameRate = 30;
                break;
        }
    }
}

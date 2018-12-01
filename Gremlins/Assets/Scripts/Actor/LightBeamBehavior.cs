using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamBehavior : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            CalculateLightbeamEdge();
            transform.hasChanged = false;
        }
    }

    private void CalculateLightbeamEdge()
    {
        if (!GetComponent<MeshFilter>())
        {
            return;
        }

        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        Material mat = GetComponent<MeshRenderer>().material;
        Vector3[] verts = mesh.vertices;
        Color[] colors = new Color[verts.Length];

        for (int i = 0; i < verts.Length; ++i)
        {
            Vector3 pos = transform.TransformPoint(verts[i]);
            Vector3 dir = pos - transform.position;
            RaycastHit[] hits = Physics.RaycastAll(transform.position, dir.normalized, dir.magnitude);
            bool isHit = false;
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("Finish"))
                {
                    if (Vector3.Distance(hit.point, pos) > 0.1f)
                    {
                        isHit = true;
                        break;
                    }
                }
            }
            
            if (isHit)
            {
                colors[i] = new Color(0, 0, 0, 0);
            }
            else
            {
                colors[i] = new Color(1, 1, 1, 1);
            }
        }

        mesh.colors = colors;
    }
}

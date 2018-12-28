using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamBehavior : ObjectControl
{
    private Mesh mesh;
    private Material mat;

    private float tweak = -5;
    private float fadeSpeed = 3f;

    // Use this for initialization
    void Start()
    {
        if (!GetComponent<MeshFilter>())
        {
            Destroy(gameObject);
        }

        mesh = GetComponent<MeshFilter>().sharedMesh;
        mat = GetComponent<MeshRenderer>().material;
        Vector3[] verts = mesh.vertices;

        float maxDist = -10000;
        for (int i = 0; i < verts.Length; ++i)
        {
            Vector3 pos = transform.TransformPoint(verts[i]);
            float dist = Vector3.Distance(pos, transform.position);
            if (dist > maxDist)
            {
                maxDist = dist;
            }
        }

        mat.SetFloat("_Tweak", tweak);
        mat.SetFloat("_MaxDistance", maxDist);
        mat.SetVector("_SourcePos", new Vector3(transform.position.x, transform.position.y, transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            CalculateLightbeamEdge();
            transform.hasChanged = false;
        }

        if (mat.GetFloat("_Tweak") != tweak)
        {
            float t = mat.GetFloat("_Tweak");
            t = Mathf.Lerp(t, tweak, Time.deltaTime * fadeSpeed);
            mat.SetFloat("_Tweak", t);
        }
    }

    private void CalculateLightbeamEdge()
    {
        if (!mesh)
        {
            return;
        }

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

    public override void Activate()
    {
        base.Activate();

        tweak = 10;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        tweak = -5;
    }
}

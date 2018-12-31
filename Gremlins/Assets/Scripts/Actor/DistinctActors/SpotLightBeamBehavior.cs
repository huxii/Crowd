using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpotLightBeamBehavior : MonoBehaviour
{
    [System.Serializable]
    public struct LightEffectSettings
    {
        public Color overlayColor;
        public float overlayIntensity;
        public float haloIntensity;
        public float overlayFactor;
        public Color softLightColor;
        public float softLightIntensity;
        public float softLightFactor;
    };

    [Header("Light Effect")]
    public LightEffectSettings darkEffect;
    public LightEffectSettings brightEffect;

    private Mesh mesh;
    private Material mat;

    private float tweak = -5;
    private float fadeSpeed = 3f;
    private float effectDuration = 1f;
    private float effectTimer = -1;

    private const string MAX_DISTANCE_STRING = "_MaxDistance";
    private const string SOURCE_POS_STRING = "_SourcePos";
    private const string TWEAK_STRING = "_Tweak";
    private const string OVERLAY_COLOR_STRING = "_Color";
    private const string OVERLAY_INTENSITY_STRING = "_Intensity";
    private const string HALO_INTENSITY_STRING = "_HaloIntensity";
    private const string OVERLAY_FACTOR = "_OverlayFactor";
    private const string SOFT_LIGHT_COLOR_STRING = "_SoftLightColor";
    private const string SOFT_LIGHT_INTENSITY_STRING = "_SoftLightIntensity";
    private const string SOFT_LIGHT_FACTOR = "_SoftLightFactor";

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

        mat.SetFloat(MAX_DISTANCE_STRING, maxDist);
        mat.SetVector(SOURCE_POS_STRING, new Vector3(transform.position.x, transform.position.y, transform.position.z));

        mat.SetFloat(TWEAK_STRING, tweak);
        mat.SetColor(OVERLAY_COLOR_STRING, darkEffect.overlayColor);
        mat.SetFloat(OVERLAY_INTENSITY_STRING, darkEffect.overlayIntensity);
        mat.SetFloat(HALO_INTENSITY_STRING, darkEffect.haloIntensity);
        mat.SetFloat(OVERLAY_FACTOR, darkEffect.overlayFactor);
        mat.SetColor(SOFT_LIGHT_COLOR_STRING, darkEffect.softLightColor);
        mat.SetFloat(SOFT_LIGHT_INTENSITY_STRING, darkEffect.softLightIntensity);
        mat.SetFloat(SOFT_LIGHT_FACTOR, darkEffect.softLightFactor);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            CalculateLightbeamEdge();
            transform.hasChanged = false;
        }

        if (mat.GetFloat(TWEAK_STRING) != tweak)
        {
            float t = mat.GetFloat(TWEAK_STRING);
            t = Mathf.Lerp(t, tweak, Time.deltaTime * fadeSpeed);
            mat.SetFloat(TWEAK_STRING, t);
        }

        if (effectTimer != -1 && effectTimer < effectDuration)
        {
            effectTimer += Time.deltaTime;

            Color c0 = darkEffect.overlayColor + (brightEffect.overlayColor - darkEffect.overlayColor) / effectDuration * effectTimer;
            float overlayIntensity = darkEffect.overlayIntensity + (brightEffect.overlayIntensity - darkEffect.overlayIntensity) / effectDuration * effectTimer;
            float haloIntensity = darkEffect.haloIntensity + (brightEffect.haloIntensity - darkEffect.haloIntensity) / effectDuration * effectTimer;
            float overlayFactor = darkEffect.overlayFactor + (brightEffect.overlayFactor - darkEffect.overlayFactor) / effectDuration * effectTimer;
            Color c1 = darkEffect.softLightColor + (brightEffect.softLightColor - darkEffect.softLightColor) / effectDuration * effectTimer;
            float softLightIntensity = darkEffect.softLightIntensity + (brightEffect.softLightIntensity - darkEffect.softLightIntensity) / effectDuration * effectTimer;
            float softLightFactor = darkEffect.softLightFactor + (brightEffect.softLightFactor - darkEffect.softLightFactor) / effectDuration * effectTimer;

            mat.SetColor(OVERLAY_COLOR_STRING, c0);
            mat.SetFloat(OVERLAY_INTENSITY_STRING, overlayIntensity);
            mat.SetFloat(HALO_INTENSITY_STRING, haloIntensity);
            mat.SetFloat(OVERLAY_FACTOR, overlayFactor);
            mat.SetColor(SOFT_LIGHT_COLOR_STRING, c1);
            mat.SetFloat(SOFT_LIGHT_INTENSITY_STRING, softLightIntensity);
            mat.SetFloat(SOFT_LIGHT_FACTOR, softLightFactor);
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

    public void On()
    {
        tweak = 10;
    }

    public void Off()
    {
        tweak = -5;
    }

    public void Transit()
    {
        effectTimer = 0;
    }
}

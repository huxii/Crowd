using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionControl : MonoBehaviour
{
    public enum TransitionStyle
    {
        DOTS,
        CIRCLE,
        FADE,
        BLACK,
        BLANK
    };

    [System.Serializable]
    public struct TransitionTexturePreset
    {
        public Texture texture;
        public Vector2 scale;
        public Vector2 offset;
        public float duration;
        public string attrName;
        public Color color;
    }

    public bool isTransiting = false;

    [Header("Transition Settings")]
    public Shader transitionShader;
    public List<TransitionTexturePreset> presets;

    GameObject transitionScreen = null;
    Camera transitionCamera = null;
    int transitionLayer = 31;
    TransitionStyle currentStyle = TransitionStyle.BLANK;

    [Header("Loading Bar Settings")]
    public Shader loadingShader;
    public float loadingBarSpeed = 1f;
    public Texture loadingBarUpTex = null;
    public Texture loadingBarDownTex = null;

    GameObject loadingBarUp = null;
    GameObject loadingBarDown = null;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Transition");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void GenerateTransitionScreen()
    {
        if (transitionScreen)
        {
            Destroy(transitionScreen);
        }

        if (!transitionCamera)
        {
            transitionCamera = gameObject.AddComponent<Camera>();
        }

        transitionCamera.orthographic = true;
        transitionCamera.orthographicSize = Services.cameraController.OrthographicSize();
        transitionCamera.nearClipPlane = -1f;
        transitionCamera.farClipPlane = 1f;
        transitionCamera.depth = float.MaxValue;
        transitionCamera.cullingMask = 1 << transitionLayer;
        transitionCamera.clearFlags = CameraClearFlags.Nothing;
        transitionCamera.enabled = false;

        // transtion screen
        transitionScreen = new GameObject();
        transitionScreen.transform.SetParent(transform);
        transitionScreen.name = "TransitionScreen";
        transitionScreen.layer = transitionLayer;
        transitionScreen.AddComponent<MeshFilter>();
        transitionScreen.AddComponent<MeshRenderer>();
        transitionScreen.SetActive(false);

        float halfHeight = transitionCamera.orthographicSize;
        float halfWidth = halfHeight * Screen.width / Screen.height;
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
                new Vector3( -halfWidth, -halfHeight, 0 ),
                new Vector3( -halfWidth, halfHeight, 0 ),
                new Vector3( halfWidth, -halfHeight, 0 ),
                new Vector3( halfWidth, halfHeight, 0 )
            };
        mesh.uv = new Vector2[]
        {
                new Vector2( 0, 0 ),
                new Vector2( 0, 1 ),
                new Vector2( 1, 0 ),
                new Vector2( 1, 1 )
        };
        mesh.triangles = new int[] { 0, 1, 2, 3, 2, 1 };
        mesh.name = "TransitionQuad";
        transitionScreen.GetComponent<MeshFilter>().mesh = mesh;

        Material mat = new Material(transitionShader);
        mat.color = Color.white;
        transitionScreen.GetComponent<MeshRenderer>().material = mat;
    }

    private void GenerateLoadingBars()
    {
        if (loadingBarUp)
        {
            Destroy(loadingBarUp);
        }

        if (loadingBarDown)
        {
            Destroy(loadingBarDown);
        }

        // loading bars
        loadingBarUp = new GameObject();
        loadingBarUp.transform.SetParent(transform);
        loadingBarUp.name = "LoadingBarUp";
        loadingBarUp.layer = transitionLayer;
        loadingBarUp.AddComponent<MeshFilter>();
        loadingBarUp.AddComponent<MeshRenderer>();
        //loadingBarUp.SetActive(false);

        loadingBarDown = new GameObject();
        loadingBarDown.transform.SetParent(transform);
        loadingBarDown.name = "LoadingBarDown";
        loadingBarDown.layer = transitionLayer;
        loadingBarDown.AddComponent<MeshFilter>();
        loadingBarDown.AddComponent<MeshRenderer>();
        //loadingBarDown.SetActive(false);

        float halfHeight = transitionCamera.orthographicSize;
        float halfBarHeight = halfHeight / 10;
        //float halfWidth = halfHeight * Screen.width / Screen.height;
        float halfWidth = halfHeight;
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
                new Vector3( -halfWidth, -halfBarHeight, 0 ),
                new Vector3( -halfWidth, halfBarHeight, 0 ),
                new Vector3( halfWidth, -halfBarHeight, 0 ),
                new Vector3( halfWidth, halfBarHeight, 0 )
            };
        mesh.uv = new Vector2[]
        {
                new Vector2( 0, 0 ),
                new Vector2( 0, 1 ),
                new Vector2( 1, 0 ),
                new Vector2( 1, 1 )
        };
        mesh.triangles = new int[] { 0, 1, 2, 3, 2, 1 };
        mesh.name = "LoadingQuad";

        loadingBarUp.GetComponent<MeshFilter>().mesh = mesh;
        loadingBarDown.GetComponent<MeshFilter>().mesh = mesh;
        loadingBarUp.transform.position = new Vector3(0, halfHeight + halfBarHeight, -0.5f);
        loadingBarDown.transform.position = new Vector3(0, -halfHeight - halfBarHeight, -0.5f);

        Material upMat = new Material(loadingShader);
        upMat.color = Color.white;
        upMat.SetFloat("_Alpha", 0);
        upMat.SetFloat("_Speed", loadingBarSpeed);
        upMat.SetTexture("_MainTex", loadingBarUpTex);
        upMat.mainTextureScale = new Vector2(7, 1);
        loadingBarUp.GetComponent<MeshRenderer>().material = upMat;

        Material downMat = new Material(loadingShader);
        downMat.color = Color.white;
        downMat.SetFloat("_Alpha", 0);
        downMat.SetFloat("_Speed", loadingBarSpeed);
        downMat.SetTexture("_MainTex", loadingBarDownTex);
        downMat.mainTextureScale = new Vector2(7, 1);
        loadingBarDown.GetComponent<MeshRenderer>().material = downMat;
    }

    public void RecordScreen()
    {
        GenerateTransitionScreen();
        GenerateLoadingBars();
        StartCoroutine(RecordFrame());
    }

    IEnumerator RecordFrame()
    {
        yield return null;
        yield return new WaitForEndOfFrame();

        var texture = ScreenCapture.CaptureScreenshotAsTexture();
        //Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGBA32, true);
        //texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //texture.Apply();

        transitionScreen.GetComponent<MeshRenderer>().material.mainTexture = texture;
        FadeIntoLoadingScreen(TransitionStyle.FADE);
        //transitionScreen.SetActive(true);
        //transitionCamera.enabled = true;
    }

    private void ApplyTransitionStyle(TransitionStyle style, float attrStartValue)
    {
        currentStyle = style;

        Material mat = transitionScreen.GetComponent<MeshRenderer>().material;
        TransitionTexturePreset texturePreset = presets[(int)style];
        mat.SetTexture("_PatternTex", texturePreset.texture);
        mat.SetTextureScale("_PatternTex", texturePreset.scale);
        mat.SetTextureOffset("_PatternTex", texturePreset.offset);
        mat.SetColor("_Color", texturePreset.color);

        mat.SetFloat("_Progress", 1);
        mat.SetFloat("_Alpha", 1);
        mat.SetFloat(presets[(int)style].attrName, attrStartValue);
    }

    private void SetTransition(bool en)
    {
        if (en)
        {
            Services.mainController.DisableInput();
            isTransiting = true;
        }
        else
        {
            Services.mainController.EnableInput();
            isTransiting = false;
        }        
    }

    public void FadeIntoLoadingScreen(TransitionStyle style)
    {
        if (transitionScreen)
        {
            if (!isTransiting)
            {
                SetTransition(true);

                ApplyTransitionStyle(style, 0);

                Services.taskManager.Do(new TimedTransitionMaterialTask(transitionScreen, transitionCamera, presets[(int)style].attrName, 0, 1, presets[(int)style].duration, false));
                Services.taskManager.Do(new TimedTransitionMaterialTask(loadingBarUp, transitionCamera, "_Alpha", 0, 1, presets[(int)style].duration, false));          
                Services.taskManager.Do(new TimedTransitionMaterialTask(loadingBarDown, transitionCamera, "_Alpha", 0, 1, presets[(int)style].duration, false));

                float halfHeight = transitionCamera.orthographicSize;
                float halfBarHeight = halfHeight / 10;
                Services.dotweenEvents.MoveTo("LoadingBarUp y " + (halfHeight - halfBarHeight).ToString() + " " + (presets[(int)style].duration).ToString());
                Services.dotweenEvents.MoveTo("LoadingBarDown y " + (-halfHeight + halfBarHeight).ToString() + " " + (presets[(int)style].duration).ToString());
            }
        }
    }

    public void FadeOutOfLoadingScreen()
    {
        FadeOutOfLoadingScreen(currentStyle);
    }

    public void FadeOutOfLoadingScreen(TransitionStyle style)
    {
        if (isTransiting)
        {
            //Debug.Log("Fade out");
            //GenerateTransitionScreen();
            ApplyTransitionStyle(style, 1);

            Services.taskManager.Do(new TimedTransitionMaterialTask(loadingBarUp, transitionCamera, "_Alpha", DataSet.magicNumber, 0, presets[(int)style].duration, false));
            Services.taskManager.Do(new TimedTransitionMaterialTask(loadingBarDown, transitionCamera, "_Alpha", DataSet.magicNumber, 0, presets[(int)style].duration, false));
            Services.taskManager.Do(new TimedTransitionMaterialTask(transitionScreen, transitionCamera, presets[(int)style].attrName, 1, 0, presets[(int)style].duration, true))
                .Then(new ActionTask(() => SetTransition(false)));

            float halfHeight = transitionCamera.orthographicSize;
            float halfBarHeight = halfHeight / 10;
            Services.dotweenEvents.MoveTo("LoadingBarUp y " + (halfHeight + halfBarHeight).ToString() + " " + (presets[(int)style].duration).ToString());
            Services.dotweenEvents.MoveTo("LoadingBarDown y " + (-halfHeight - halfBarHeight).ToString() + " " + (presets[(int)style].duration).ToString());
        }
    }



    //public void ZoomInTransitionScreen(TransitionStyle style)
    //{
    //    ApplyTransitionStyle(style, 1);

    //    Services.taskManager.Do(new TimedTransitionZoomTask(transitionScreen, transitionCamera, 4, 0, 1, presets[(int)style].duration, false));
    //}

    //public void ZoomOutTransitionScreen(TransitionStyle style)
    //{
    //    ApplyTransitionStyle(style, 1);

    //    Services.taskManager.Do(new TimedTransitionZoomTask(transitionScreen, transitionCamera, 8, 0, 1, presets[(int)style].duration, true));
    //}
}
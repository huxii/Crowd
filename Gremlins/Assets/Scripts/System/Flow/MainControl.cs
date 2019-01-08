using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    protected virtual void Awake()
    {
        Services.Init();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Services.utils.CheckPlatform();

        RegisterEvents();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Services.Update();
    }

    protected virtual void OnDestroy()
    {
        UnregisterEvents();

        Services.Destroy();
    }

    protected virtual void RegisterEvents()
    {
    }

    protected virtual void UnregisterEvents()
    {
    }

    public virtual void Ending()
    {
    }
}

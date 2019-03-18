using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    public bool statusOn = true;

    protected bool hasEnded = false;

    protected virtual void Awake()
    {
        Services.Init();

        SwitchStatus(statusOn);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Services.utils.CheckPlatform();

        if (!DataSet.isInputEnabled)
        {
            DisableInput();
        }
        else
        {
            EnableInput();
        }

        RegisterEvents();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Services.Update();
    }

    protected virtual void OnApplicationQuit()
    {
        UnregisterEvents();

        Services.Destroy();
    }

    protected virtual void OnLevelWasLoaded(int level)
    {
        Services.fmodController.UpdateBGM(level);
    }

    protected virtual void RegisterEvents()
    {
    }

    protected virtual void UnregisterEvents()
    {
    }

    public virtual void Ending(bool cleared = false)
    {
        hasEnded = true;
        DisableInput();
    }

    public virtual void EnableInput()
    {
        DataSet.isInputEnabled = true;
    }

    public virtual void DisableInput()
    {
        DataSet.isInputEnabled = false;
    }

    public virtual void UpdateParallaxScrolling()
    {
    }

    public void SwitchStatus(bool en)
    {
        GetComponent<FPSDisplay>().enabled = en;
    }
}

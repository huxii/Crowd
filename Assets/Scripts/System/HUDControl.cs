﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{
    public GameObject holdProgressBar;

    // Use this for initialization
    void Start()
    {
        holdProgressBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (holdProgressBar.active)
        {
            holdProgressBar.GetComponent<Image>().fillAmount += Time.deltaTime;
        }
    }

    public void CreateHoldIcon(GameObject obj)
    {
        holdProgressBar.SetActive(true);
        holdProgressBar.transform.position = obj.transform.position + new Vector3(0, 0, -2);
        holdProgressBar.GetComponent<Image>().fillAmount = 0;
    }

    public void DestroyHoldIcon(GameObject obj)
    {
        holdProgressBar.SetActive(false);
        holdProgressBar.GetComponent<Image>().fillAmount = 0;
    }
}

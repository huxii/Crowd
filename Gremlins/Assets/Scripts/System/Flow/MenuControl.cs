using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject levelScroll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        levelScroll.GetComponent<ScrollRect>().enabled = false;
    }
}

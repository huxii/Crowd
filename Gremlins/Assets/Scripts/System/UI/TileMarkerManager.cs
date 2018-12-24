using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMarkerManager : MonoBehaviour
{
    private GameObject gridProjector;

    // Use this for initialization
    void Start()
    {
        gridProjector = Instantiate(Resources.Load<GameObject>("Prefabs/GridProjector") as GameObject, Vector3.zero, Quaternion.identity);
    }

    public void Activate(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }

        gridProjector.transform.SetParent(obj.transform);
        gridProjector.transform.localPosition = Vector3.zero;
        gridProjector.SetActive(true);
        gridProjector.GetComponentInChildren<TileMarkerBehavior>().Activate();
    }

    public void Deactivate()
    {
        gridProjector.SetActive(false);
    }
}

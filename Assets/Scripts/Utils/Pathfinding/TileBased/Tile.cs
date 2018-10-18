using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float tileSize = 1f;
    public GameObject followObject = null;
    public Vector3 followOffset;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (followObject != null)
        {
            transform.position = followObject.transform.position + followOffset;
        }
    }

    private void OnDrawGizmos()
    {
        UpdatePosition();

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, new Vector3(tileSize, tileSize, tileSize));
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

    private void OnDrawGizmosSelected()
    {
        UpdatePosition();

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(tileSize, tileSize, tileSize));
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    // 2. make the datatype (GameObject, struct, etc.) that need to be saved serializable
    [SerializeField]
    public GameObject followObject = null;
    [SerializeField]
    public GameObject followPoint = null;
    [SerializeField]
    public Vector3 followOffset;
    [SerializeField]
    public bool isBorder = false;

    [HideInInspector]
    public float pointSize = 1f;

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
        else
        if (followPoint != null)
        {
            transform.position = followPoint.transform.position + followOffset;
        }
    }

    private void OnDrawGizmos()
    {
        UpdatePosition();
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, pointSize);
    }

    private void OnDrawGizmosSelected()
    {
        UpdatePosition();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pointSize);
    }
}

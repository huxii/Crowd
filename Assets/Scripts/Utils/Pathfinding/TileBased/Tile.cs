using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float tileSize = 1f;
    public GameObject followObject = null;
    public Vector3 followOffset;

    [SerializeField]
    private List<GameObject> menOnThis = new List<GameObject>();

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Man"))
        {
            GameObject man = other.gameObject;
            if (followObject != null && followObject.GetComponent<ObjectHolderControl>() != null && !followObject.GetComponent<ObjectHolderControl>().IsActivated())
            {
                Services.gameController.DropMan(man);
            }
            else
            {
                if (!menOnThis.Contains(man))
                {
                    menOnThis.Add(man);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Man"))
        {
            GameObject man = other.gameObject;
            if (menOnThis.Contains(man))
            {
                menOnThis.Remove(man);
            }
        }
    }

    public void OnParentDeactive()
    {       
        foreach (GameObject man in menOnThis)
        {
            Services.gameController.DropMan(man);
        }

        menOnThis.Clear();
    }
}

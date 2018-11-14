using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEdge : MonoBehaviour
{
    public enum MovementType
    {
        WALK,
        CLIMB,
    };

    public MovementType type = MovementType.WALK;

    public GameObject t0;
    public GameObject t1;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnDrawGizmos()
    {
        if (t0 == null || t1 == null)
        {
            DestroyImmediate(gameObject);
        }

        Gizmos.color = Color.white;
        Gizmos.DrawLine(t0.transform.position, t1.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        if (t0 == null || t1 == null)
        {
            DestroyImmediate(gameObject);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(t0.transform.position, t1.transform.position);
    }
}

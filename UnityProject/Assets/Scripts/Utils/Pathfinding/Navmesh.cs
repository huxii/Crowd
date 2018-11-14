using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navmesh : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

        Gizmos.matrix *= cubeTransform;

        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }

    private void OnDrawGizmosSelected()
    {
        Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

        Gizmos.matrix *= cubeTransform;

        Gizmos.color = new Color(0, 1, 0, 0.7f);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }
}

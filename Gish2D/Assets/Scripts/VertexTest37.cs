using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexTest37 : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] vertices;



    public List<GameObject> points;
    public GameObject toBeIstantiated;
    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            {

                GameObject childObject = Instantiate(toBeIstantiated, gameObject.transform.position + vertices[i], Quaternion.identity) as GameObject;
                childObject.transform.parent = gameObject.transform;
                points.Add(childObject);
            }
        }

        for (int i = 0; i < points.Count; i++)
        {

            if (i != 1)
                points[i].GetComponent<SpringJoint2D>().connectedBody = points[1].GetComponent<Rigidbody2D>();
            //else
            // points[i].GetComponent<SpringJoint2D>().enabled = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = points[i].transform.localPosition;
        }
        mesh.vertices = vertices;

    }
}
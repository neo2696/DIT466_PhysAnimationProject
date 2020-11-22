﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexTest : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] vertices;
    public Vector3[] normals;
    public int CenterPoint;
    public int verticiesCount;



    public List<GameObject> points;
    public GameObject toBeIstantiated;
    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticiesCount = vertices.Length;

        for(int i=0; i<vertices.Length; i++)
        {
            GameObject childObject = Instantiate(toBeIstantiated, gameObject.transform.position + vertices[i], Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            points.Add(childObject);
        }

        for(int i=0; i<points.Count; i++)
        {
            if (i == points.Count - 1)
                points[i].GetComponent<HingeJoint2D>().connectedBody = points[0].GetComponent<Rigidbody2D>();
            else
            points[i].GetComponent<HingeJoint2D>().connectedBody = points[i+1].GetComponent<Rigidbody2D>();
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
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();


    }
}
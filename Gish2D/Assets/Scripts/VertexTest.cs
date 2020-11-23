using System.Collections;
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

    void AddSpring(int i0, int i1)
    {
        SpringJoint2D sj = points[i0].AddComponent<SpringJoint2D>();
        sj.connectedBody = points[i1].GetComponent<Rigidbody2D>();
        sj.autoConfigureConnectedAnchor = true;
    }

    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticiesCount = vertices.Length;

        for(int i=0; i<vertices.Length; i++)
        {
            Vector2 pos = new Vector2(mesh.vertices[i].x, mesh.vertices[i].y);
            pos = transform.TransformPoint(pos);
            GameObject childObject = Instantiate(toBeIstantiated, pos, Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            points.Add(childObject);
        }
        /*
        for(int i=0; i<points.Count; i++)
        {
            Vector2 pos0 = points[i].transform.position;

            for(int j=0; j<points.Count; j++)
            {
                if (i == j)
                    continue;

                Vector2 pos1 = points[j].transform.position;

                if((pos0 - pos1).magnitude < 1.0f)
                {
                    AddSpring(i, j);
                }
            }
        }
        */




        
        for(int i=0; i<points.Count; i++)
        {
            if (i == points.Count - 1)
                points[i].GetComponent<HingeJoint2D>().connectedBody = points[0].GetComponent<Rigidbody2D>();
            else
            points[i].GetComponent<HingeJoint2D>().connectedBody = points[i+1].GetComponent<Rigidbody2D>();
        }
     
        transform.position = Vector2.zero;


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
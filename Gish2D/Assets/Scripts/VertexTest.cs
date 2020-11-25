using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexTest : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] vertices;
    public int CenterPoint;
    public int verticiesCount;



    public List<GameObject> points;
    public GameObject toBeIstantiated;

    void AddSpring(int i0, int i1)
    {
        SpringJoint2D sj = points[i0].AddComponent<SpringJoint2D>();
        sj.connectedBody = points[i1].GetComponent<Rigidbody2D>();
        sj.autoConfigureConnectedAnchor = true;
        sj.dampingRatio = 1;        
        sj.frequency = 10;      //stiffness
    }

    void AddHinge(int i0, int i1)
    {
        HingeJoint2D hj = points[i0].AddComponent<HingeJoint2D>();
        hj.connectedBody = points[i1].GetComponent<Rigidbody2D>();
        hj.autoConfigureConnectedAnchor = true;
      //  hj.useLimits = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticiesCount = vertices.Length;

        for(int i=0; i<vertices.Length; i++)
        {
          
            GameObject childObject = Instantiate(toBeIstantiated, gameObject.transform.position + vertices[i], Quaternion.identity) as GameObject;
            childObject.transform.parent = gameObject.transform;
            points.Add(childObject);
        }

        
        for (int i = 0; i < points.Count; i++)
        {
            Vector3 pos0 = points[i].transform.position;
            for (int j = 0; j < points.Count; j++)
            {
                {
                    if (i == j)
                        continue;
                    Vector3 pos1 = points[j].transform.position;
                    if (((pos0 - pos1).magnitude < 0.8f))
                    {
                        AddSpring(i,j);
                    }
                }
            }
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
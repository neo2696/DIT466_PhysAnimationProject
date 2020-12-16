using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    private Rigidbody2D rb; 
    public int EnemySpeed;
    public int XMoveDirection;

    private void Start()
    {
        XMoveDirection = -1;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // rb.AddForce(new Vector2(XMoveDirection ,0) * EnemySpeed);
        rb.velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall Left End"))
        {
            XMoveDirection = 2;
            transform.Rotate(180, 0, 180);
            
        }
        if (collision.CompareTag("Wall Right End"))
        {
            XMoveDirection = -2;
            transform.Rotate(0, 180, 0);
        }
    }
}

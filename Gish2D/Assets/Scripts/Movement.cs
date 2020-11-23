using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpPower;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(new Vector2(0, 5));

        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(new Vector2(0, -5));

        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(new Vector2(-5, 0));

        if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(new Vector2(5, 0));


        /*
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
        Run(direction);

        if (Input.GetButtonDown("Jump"))
        {

            Jump(Vector2.up);

        }
        */
    }

    /*
    public void Run(Vector2 dir)
    {

        rb.AddForce(new Vector2(dir.x * speed, 0));

    }

    public void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpPower;
    }
    */
}

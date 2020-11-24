using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpPower;
    bool triggerEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
        Run(direction);
        Debug.Log(triggerEntered);
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Jump(Vector2.up);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Tilemap")
        {
            triggerEntered = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if(collision.CompareTag("Floor") )
        {
            triggerEntered = true;
        }
    }


    public void Run(Vector2 dir)
    {

        rb.AddForce(new Vector2(dir.x * speed, 0));

    }

    public void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpPower;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpPower;
    bool triggerEntered = false;
    private GameMaster gm;

    //Inspector variables

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
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
            GameObject.Find("Jump").GetComponent<AudioSource>().Play();
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
            GameObject.Find("Death").GetComponent<AudioSource>().Play();
            Movement.GishDied();
        }

        if(collision.CompareTag("Floor") )
        {
            triggerEntered = true;
        }

        if (collision.CompareTag("Coin"))
        {
            GameObject.Find("CoinSound").GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            gm.points += 1;
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

    public static void GishDied()
    {
        GameOverWindow.ShowStatic();
    }
  
}

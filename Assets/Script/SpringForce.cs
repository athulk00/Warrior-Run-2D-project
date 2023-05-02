using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForce : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool jump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(jump == true)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, 20f);
        }
        else
        {
            rb.gravityScale = 3f;

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spring"))
        {
            Debug.Log("Colliding");
            jump = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Spring"))
        {
            jump = false;
        }
    }
}

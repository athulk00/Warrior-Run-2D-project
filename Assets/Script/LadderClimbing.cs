using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    private float verticalDir;
    [SerializeField] private float climbingSpeed = 3f;
    private Rigidbody2D rb;
    private bool isClimbing;
    private bool isLadder;
    private float originalGravityScale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
        
    }
    private void Update()
    {
        verticalDir = Input.GetAxis("Vertical");
        
        if (isLadder && verticalDir > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalDir * climbingSpeed);
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if(isClimbing == true)
        {
            rb.gravityScale = 0;
            
        }
        else if(isClimbing == false)
        {
            rb.gravityScale = originalGravityScale;
            
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            
        }
    }


}

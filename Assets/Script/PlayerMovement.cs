using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX;
    public Transform rayPos1;
    public Transform rayPos2;
    private Transform currentRayPos;
    private float damage = 10f;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] LayerMask groundMask;

   
    
    public enum MovementState { idle, run, jump, fall, attack1, attack2, hit}
    public MovementState state;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        

        MovementUpdate();
        AnimationUpdate();
    }
    public void MovementUpdate()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
    }
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundMask);
    }
    public void AnimationUpdate()
    {
        
        if(dirX > 0)
        {
            state = MovementState.run;
            sprite.flipX = false;
            
        }
        else if(dirX < 0)
        {
            state = MovementState.run;
            sprite.flipX = true;
            
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            state = MovementState.attack1;
            Attack();

        }
       
     
        anim.SetInteger("State", (int)state);
    }
    public void Attack()
    {
        if(sprite.flipX == false)
        {
            currentRayPos = rayPos1;

        }
        else if(sprite.flipX == true)
        {
            currentRayPos = rayPos2;
        }
        RaycastHit2D hit = Physics2D.Raycast(currentRayPos.position, currentRayPos.forward, 2f);
        if(hit.collider != null && hit.collider.tag != "Apple")
        {
            hit.collider.gameObject.GetComponent<PlayerTarget>().TakeDamageEnemy(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public float playerHealth = 10f;
    public float playerCurrentHealth;
    public Animator anim;
    private PlayerMovement playerMovement;
    public Collider2D coll;
    public Rigidbody2D rb;
    void Start()
    {
        playerCurrentHealth = playerHealth;
        //anim = GetComponent<Animator>();
        //playerMovement = GetComponent<PlayerMovement>();
        //coll = GetComponent<Collider2D>();
        //rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float amount)
    {
        

        playerCurrentHealth -=  amount;
        
        if(playerCurrentHealth <= 0f)
        {
            Die();
        }
        
    }
    public void Die()
    { 
        anim.SetTrigger("Death");
        rb.isKinematic = true;
        Destroy(coll);
        
    }
}

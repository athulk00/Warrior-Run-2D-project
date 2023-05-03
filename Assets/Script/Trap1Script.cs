using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1Script : MonoBehaviour
{
    private float damage = 5f;
    public EnemyTarget enemyTarget;
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
           enemyTarget.TakeDamage(damage);
            
        }
        
        
       
    }

  
}

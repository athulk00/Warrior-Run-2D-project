using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public float enemyHealth = 10f;
    public float currentHealth;
    private Animator anim;
    private EnemyMovement enemyMovement;
    void Start()
    {
        currentHealth = enemyHealth;
        anim = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    public void TakeDamageEnemy(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Debug.Log("Enemy Die");
            EnemyDie();
        }
    }

    public void EnemyDie()
    {
        anim.SetTrigger("Death");
        enemyMovement.enabled = false;
        Destroy(gameObject, 1f);
    }
    
}

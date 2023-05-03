using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public float enemyHealth = 50f;
    public float currentHealth;
    private Animator anim;
    private EnemyMovement enemyMovement;
    public GameObject apple;
    private Vector3 enemyPosition;
    private bool flag = false;
    void Start()
    {
        currentHealth = enemyHealth;
        enemyPosition = transform.position;
        anim = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    private void Update()
    {
        
    }
    public void TakeDamageEnemy(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            
            EnemyDie();
            

        }
    }

    public void EnemyDie()
    {

        anim.SetTrigger("Death");
        enemyMovement.enabled = false;
        Invoke(nameof(DestroyEnenemy), 1f);
        Invoke(nameof(SpawnApple),1f);
        
        




    }
    public void DestroyEnenemy()
    {

        // gameObject.SetActive(false);
        Destroy(gameObject);
    }
    public void SpawnApple()
    {
        if (flag == false)
        {
            Instantiate(apple, transform.position, Quaternion.identity);
        }
        flag = true;
    }
    


}

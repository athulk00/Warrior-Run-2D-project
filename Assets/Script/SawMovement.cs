using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public EnemyTarget target;
    public float damage = 100f;
    private int currentPos = 0;
    [SerializeField] private GameObject[] wayPoints;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.AddTorque(2f);
        if(Vector2.Distance(wayPoints[currentPos].transform.position, transform.position) < 0.1f)
        {
            currentPos++;
            if(currentPos >= wayPoints.Length)
            {
                currentPos = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentPos].transform.position, Time.deltaTime * 3f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            target.TakeDamage(damage);
        }
    }

}

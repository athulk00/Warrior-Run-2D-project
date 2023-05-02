using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeFalling : MonoBehaviour
{
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
           

            StartCoroutine(ActivateBridgeFall());
            
        }
    }

    IEnumerator ActivateBridgeFall()
    {
        yield return new WaitForSeconds(1f);
        rb.isKinematic = false;
        rb.gravityScale = 2f;
        Destroy(gameObject, 0.5f);
    }
}

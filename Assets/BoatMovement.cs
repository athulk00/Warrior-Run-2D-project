using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public Transform target;
    public float boatSpeed = 2f;
    private bool insideBoat;

    public void Update()
    {
        if(insideBoat == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * boatSpeed);
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Collided");
            GameObject collidedObject = collision.gameObject;
            collidedObject.transform.parent = transform;
            insideBoat = true;
        }
    }
}

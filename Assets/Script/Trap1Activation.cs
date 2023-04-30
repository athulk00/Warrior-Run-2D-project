using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1Activation : MonoBehaviour
{
    public GameObject trap;
    private GameObject newObject;
    public Transform trapPoint;
    public Rigidbody2D trapRb;
    private int currentPos = 0;
    private bool flag;
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && !flag)
        {

            trapRb.isKinematic = false;
            flag = true;
            Destroy(trap, 3f);
            
            
        }
    }
   /* IEnumerator InstantiateObject()
    {

         for(int i = 0; i< 10; i++)
        {
            newObject = Instantiate(trap, trapPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
            Destroy(newObject, 0.2f);
        }
      
            

        
       
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCollection : MonoBehaviour
{
    public int count = 0;
    public int CountStore = 0;
    public Text scoreUpdate;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            count++;
            Debug.Log(count);
            scoreUpdate.text = "SCORE : " + count;
        }

    }
}

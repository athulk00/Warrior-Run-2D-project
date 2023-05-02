using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentPos = 0;
    [SerializeField] private float moveSpeed = 5f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
       if(Vector2.Distance(wayPoints[currentPos].transform.position, transform.position) < 0.1f)
        {
            currentPos++;
            if(currentPos >= wayPoints.Length)
            {
                currentPos = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentPos].transform.position, Time.deltaTime * moveSpeed);
    }
}

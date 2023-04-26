using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float camOffset;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(player != null)
        {
            this.transform.position = new Vector3(player.position.x, player.position.y - camOffset, -10f);
        }
        
    }
}

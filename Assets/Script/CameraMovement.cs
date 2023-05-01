using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector2 camOffset;
    public float smoothTime = 0.3f;

    public float minCameraX;
    public float maxCameraX;
    public float minCameraY;
    public float maxCameraY;

    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        if(player != null)
        {
            Vector2 playerPos = new Vector2(player.position.x, player.position.y);
            Vector2 targetPos = playerPos + camOffset;
            targetPos.x = Mathf.Clamp(transform.position.x, minCameraX, maxCameraX);
            targetPos.y = Mathf.Clamp(transform.position.y, minCameraY, maxCameraY);

            transform.position = Vector3.SmoothDamp(player.position, targetPos, ref velocity, smoothTime);
        }
        
    }
}

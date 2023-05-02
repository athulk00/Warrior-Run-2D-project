using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 lastMousePos = Vector2.zero;
    Vector2 currentMousePos;
    private bool isMouseClicked;
    private Camera mainCamera;
    private Collider2D coll;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }
    public void Update()
    {
        if(isMouseClicked == true)
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
            Vector2 center = coll.bounds.center;
            if(mousePos.x < center.x)
            {
                rb.angularVelocity = 100f;
            }
            if(mousePos.x > center.x)
            {
                rb.angularVelocity = -100f;
            }
            

        }
        else
        {
            rb.angularVelocity = 0f;
        }
        
    }
    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isMouseClicked = true;
        }
    }
    private void OnMouseUp()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isMouseClicked = false;
        }
        
    }


}

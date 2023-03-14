using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuickSand : MonoBehaviour
{
    public GameObject playerGameObject;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb = playerGameObject.GetComponent<Rigidbody2D>();

    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.gravityScale = 0.05f;
        };
        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.gravityScale = 5;     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rb.gravityScale = 0.05f;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        rb.gravityScale = 5;
    }
}

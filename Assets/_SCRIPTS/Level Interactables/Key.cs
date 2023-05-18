using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public float speed = 2f;
    public float heightOnPlayer = 0.1f;
    public float height = 0.01f;
    public bool hasKey = false;
    public bool keyUsed = false;
    public GameObject player;
    public Vector2 playerPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (keyUsed == false)
            {
                playerPos = player.transform.position;

                if (hasKey == false)
                {   
                    float newY = Mathf.Sin(Time.time * speed);
                    transform.position = new Vector2(transform.position.x, (newY * height) + transform.position.y);
                }
                if (hasKey == true)
                {
                    float newY = Mathf.Sin(Time.time * speed);
                    transform.position = new Vector2(playerPos.x, (newY * heightOnPlayer) + (playerPos.y + 1.5f));
                }
            }
        }
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasKey = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShoot : MonoBehaviour
{

    public Vector2 Origin;
    public bool isShooting = false;
    public GameObject dart;
    public Rigidbody2D rb;
    public float timer;

    private StatsComponent statsComponent;

    void Start()
    {
        Origin = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        statsComponent = GameObject.FindWithTag("Player").GetComponentInChildren<StatsComponent>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Collider")
        {
            DamageInterface damageable = collision.GetComponent<DamageInterface>();
        
            if (collision.CompareTag("Player"))
            {
                damageable.Damage(50);
            }
            gameObject.transform.position = (Origin);
            Debug.Log(gameObject.transform.position);
            rb.velocity = new Vector2(0,0);
            StartCoroutine(Timer());
            isShooting = false;
        }
        

    }

    public void shootDart()
    {

        Debug.Log("Check 2");
        isShooting = true;
        rb.velocity = new Vector2(-10,0);

    }

    IEnumerator Timer()
    {
        Debug.Log("Check");
        yield return new WaitForSeconds(2);
    }
}

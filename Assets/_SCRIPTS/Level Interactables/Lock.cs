using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    public GameObject Key;
    public Key keyScript;


    // Start is called before the first frame update
    void Start()
    {
        keyScript = Key.GetComponent<Key>();
    }

    void Update()
    {
        if (keyScript.keyUsed == true)
        {
            Key.transform.position = Vector2.MoveTowards(Key.transform.position, transform.position, 3f * Time.deltaTime);
            StartCoroutine(Timer());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (keyScript.hasKey)
            {
                keyScript.keyUsed = true;

            }
        }
    }


    IEnumerator Timer()
    {
        Debug.Log("Check");
        yield return new WaitForSeconds(2);
        Destroy(Key);
        Destroy(gameObject);
    }

}

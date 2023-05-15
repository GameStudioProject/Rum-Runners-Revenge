using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1f;
    public float destroyDelay = 2f;
    public Vector3 Origin;
    public Quaternion OriginR;

    [SerializeField] private Rigidbody2D rb;


    void Start()
    {
        Origin = this.gameObject.transform.position;
        OriginR = this.gameObject.transform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 1f;
        yield return new WaitForSeconds(4);
        this.gameObject.transform.position = Origin;
        this.gameObject.transform.rotation = OriginR;
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
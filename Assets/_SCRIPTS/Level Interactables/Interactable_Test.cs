using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Interactable_Test : MonoBehaviour
{
    public Tilemap tileMap;
    public Tilemap collapseTile;
    public float delay = 1f;
    public float force = 500f;

    private bool collapsing = false;



    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collided");
        if (other.gameObject.CompareTag("Player") && !collapsing)
        {
            collapsing = true;
            StartCoroutine(Collapse());
        }
        
    }

    private IEnumerator Collapse()
    {
        Vector3Int cellPosition = tileMap.WorldToCell(transform.position);
        //TileBase tile = tileMap.GetTile(cellPosition);
        Rigidbody2D tileRigidbody = tileMap.GetInstantiatedObject(cellPosition).GetComponent<Rigidbody2D>();


        tileMap.SetTile(cellPosition, (Tile)collapseTile);
        tileRigidbody.bodyType = RigidbodyType2D.Dynamic;
        tileRigidbody.AddForce(Vector2.down * force);

        yield return new WaitForSeconds(delay);

        Destroy(tileRigidbody.gameObject);
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;


public class BreakableBridge : MonoBehaviour {
    
    public float breakDelay = 0.5f; // Delay before the bridge starts breaking

    private bool isBreaking = false; // Flag to check if the bridge is currently breaking

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player") && !isBreaking) {
            StartCoroutine(BreakBridge());
        }
    }

    IEnumerator BreakBridge() {
        isBreaking = true;
        yield return new WaitForSeconds(breakDelay);

        Tilemap tilemap = GetComponent<Tilemap>();

        List<Vector3Int> allTilePositions = new List<Vector3Int>();
        foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
        {
            allTilePositions.Add(position);
        }

        // Convert the list to an array
        Vector3Int[] positionsArray = allTilePositions.ToArray();
        foreach (Vector3Int tilePosition in allTilePositions)
        {
            TileBase tile = tilemap.GetTile(tilePosition);
            if (tile != null)
            {
                // Add a Rigidbody2D component to the tile
                GameObject tileObj = tilemap.gameObject;
                Rigidbody2D rb = tileObj.AddComponent<Rigidbody2D>();
                TilemapCollider2D collider = tileObj.GetComponent<TilemapCollider2D>();

                // Enable gravity on the Rigidbody2D component
                rb.gravityScale = 1;
                collider.enabled = false;


                // Remove the tile from the Tilemap
                //tilemap.SetTile(tilePosition, null);

                // Wait for a short time before removing the next tile
                //yield return new WaitForSeconds(breakSpeed);
            }
        }
    }
}
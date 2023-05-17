using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class CollectibleDestroy : MonoBehaviour
    {

        public GameObject collectible;

        void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.CompareTag("Player"))
            {
                collectible.GetComponent<CollectibleScript>().count = collectible.GetComponent<CollectibleScript>().count + 0.5;
                GameObject.Find("Treasure Audio").GetComponent<AudioSource>().Play();
                Destroy(this.gameObject);
            }
        }
    }
}

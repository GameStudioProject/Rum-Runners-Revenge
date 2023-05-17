using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Tomas
{
    public class CaveEnter : MonoBehaviour
    {

        public Light2D light;
        public GameObject worldLight;

        public GameObject BG_Cave;
        public GameObject BG_Island;
        
        public bool enter = false;
        
        void Start()
        {
            light = worldLight.GetComponent<Light2D>();
        }

        void Update() 
        {
            if(enter)
            {
                light.intensity = Mathf.Lerp(light.intensity, 0.1f, 0.01f);
                if (light.intensity <= 0.11f)
                {
                    enter = false;
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other) 
        {
            BG_Cave.SetActive(true);
            BG_Island.SetActive(false);
            enter = true;
        }
    }
}

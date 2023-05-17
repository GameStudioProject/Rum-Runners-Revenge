using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Tomas
{
    public class CaveExit : MonoBehaviour
    {

        public Light2D light;
        public GameObject worldLight;

        public GameObject BG_Cave;
        public GameObject BG_Island;
        
        public bool exit = false;
        
        void Start()
        {
            light = worldLight.GetComponent<Light2D>();
        }

        void Update() 
        {
            if(exit)
            {
                light.intensity = Mathf.Lerp(light.intensity, 0.71f, 0.01f);
                if (light.intensity > 0.69f)
                {
                    exit = false;
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other) 
        {
            BG_Cave.SetActive(false);
            BG_Island.SetActive(true);
            exit = true;
        }
    }
}

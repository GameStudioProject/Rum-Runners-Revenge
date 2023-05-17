using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Tomas
{
    public class LightChange : MonoBehaviour
    {
        public GameObject LevelClearCheck;
        public Light2D light;
        public GameObject worldLight;

        public GameObject BG_Cave;
        public GameObject BG_Island;

        // Start is called before the first frame update
        void Start()
        {
            light = worldLight.GetComponent<Light2D>();

        }

        // Update is called once per frame
        void Update()
        {
            if( LevelClearCheck.GetComponent<LevelClear>().levelFinished)
            {
                BG_Cave.SetActive(false);
                BG_Island.SetActive(true);
                Debug.Log("Check");
                light.intensity = Mathf.Lerp(light.intensity, 0.71f, 0.01f);
                if (light.intensity > 0.69f)
                {
                    LevelClearCheck.GetComponent<LevelClear>().levelFinished = false;
                }
            }
        }
    }
}

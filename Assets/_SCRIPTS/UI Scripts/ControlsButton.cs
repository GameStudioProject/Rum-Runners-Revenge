using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class ControlsButton : MonoBehaviour
    {

        public GameObject controlsCanvas;

        public void controlsButton()
        {
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            controlsCanvas.SetActive(true);
        }
        
    }
}

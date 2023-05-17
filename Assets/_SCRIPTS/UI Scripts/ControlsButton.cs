using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tomas
{
    public class ControlsButton : MonoBehaviour
    {

        public GameObject controlsCanvas;
        public Button backButton;

        public void controlsButton()
        {
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            controlsCanvas.SetActive(true);
            backButton.Select();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tomas
{
    public class ControlsBackButton : MonoBehaviour
    {
       public GameObject controlsCanvas;
       public Button controls;

        public void controlsBackButton()
        {
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            controlsCanvas.SetActive(false);
            controls.Select();
        }
    }
}

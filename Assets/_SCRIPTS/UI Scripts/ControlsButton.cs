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
            controlsCanvas.SetActive(true);
        }
        
    }
}

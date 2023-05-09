using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class ControlsBackButton : MonoBehaviour
    {
       public GameObject controlsCanvas;

        public void controlsBackButton()
        {
            controlsCanvas.SetActive(false);
        }
    }
}

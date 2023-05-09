using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class OptionsButton : MonoBehaviour
    {

        public GameObject optionsCanvas;

        public void optionsButton()
        {
            optionsCanvas.SetActive(true);
        }
        
    }
}

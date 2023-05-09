using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class OptionsBackButton : MonoBehaviour
    {
        public GameObject optionsCanvas;

        public void optionsBackButton()
        {
            optionsCanvas.SetActive(false);
        }
    }
}

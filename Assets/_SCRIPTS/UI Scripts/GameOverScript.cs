using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class GameOverScript : MonoBehaviour
    {

        public GameObject gameOverCanvas;

        public void CanvasEnable()
        {
            gameOverCanvas.SetActive(true);
        }

        public void CanvasDisable()
        {
            gameOverCanvas.SetActive(false);
        }

    }
}

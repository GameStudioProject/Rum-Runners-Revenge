using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class PauseMenuCheck : MonoBehaviour
    {
        
        public GameObject pauseMenuCanvas;
        public PlayerInputHandler playerInputHandler;

        public bool optionsMenuUp = false;

        void Update()
        {
            if (playerInputHandler.PauseMenuInput == true)
            {
                if (optionsMenuUp == false)
                {
                    if (playerInputHandler.pauseMenuUp == false)
                    {
                        pauseMenuCanvas.SetActive(true);
                        playerInputHandler.pauseMenuUp = true;
                        playerInputHandler.PauseMenuInput = false;
                        Time.timeScale = 0;
                    }

                    else if (playerInputHandler.pauseMenuUp == true)
                    {
                        pauseMenuCanvas.SetActive(false);
                        playerInputHandler.pauseMenuUp = false;
                        playerInputHandler.PauseMenuInput = false;
                        Time.timeScale = 1;
                    }
                }
                
                
            }

        }
    }
}

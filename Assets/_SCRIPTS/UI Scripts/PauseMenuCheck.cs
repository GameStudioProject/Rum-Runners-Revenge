using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tomas
{
    public class PauseMenuCheck : MonoBehaviour
    {
        
        public GameObject pauseMenuCanvas;
        public PlayerInputHandler playerInputHandler;
        public Button Resume;

        public GameObject UI;
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
                        UI.SetActive(false);
                        Resume.Select();
                        playerInputHandler.pauseMenuUp = true;
                        playerInputHandler.PauseMenuInput = false;
                        Time.timeScale = 0;
                    }

                    else if (playerInputHandler.pauseMenuUp == true)
                    {
                        pauseMenuCanvas.SetActive(false);
                        UI.SetActive(true);
                        playerInputHandler.pauseMenuUp = false;
                        playerInputHandler.PauseMenuInput = false;
                        Time.timeScale = 1;
                    }
                }
                
                
            }

        }
    }
}

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
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            optionsCanvas.SetActive(true);
            PlayerManager.instance.player.GetComponent<PauseMenuCheck>().optionsMenuUp = true;
        }
        
        public void update()
        {
            if (PlayerManager.instance.player.GetComponent<PauseMenuCheck>().optionsMenuUp == true)
            {
                if (PlayerManager.instance.player.PlayerInputHandler.PauseMenuInput == true)
                {
                    Debug.Log("Test");
                    GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
                    optionsCanvas.SetActive(false);
                    PlayerManager.instance.player.GetComponent<PauseMenuCheck>().optionsMenuUp = false;
                    PlayerManager.instance.player.PlayerInputHandler.PauseMenuInput = false;
                }
            }
        }
    }
}

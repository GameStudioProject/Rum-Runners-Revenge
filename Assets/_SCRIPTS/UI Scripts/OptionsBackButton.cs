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
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            optionsCanvas.SetActive(false);
            PlayerManager.instance.player.GetComponent<PauseMenuCheck>().optionsMenuUp = false;
        }
    }
}

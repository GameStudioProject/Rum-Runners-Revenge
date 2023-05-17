using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tomas
{
    public class OptionsBackButton : MonoBehaviour
    {
        public GameObject optionsCanvas;
        public Button play;

        public void optionsBackButton()
        {
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            optionsCanvas.SetActive(false);
            play.Select();
            PlayerManager.instance.player.GetComponent<PauseMenuCheck>().optionsMenuUp = false;
        }
    }
}

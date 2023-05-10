using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class ResumeButton : MonoBehaviour
    {
        public PlayerInputHandler playerInputHandler;

        public void resumeButton()
        {
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            playerInputHandler.PauseMenuInput = true;
        }
    }
}

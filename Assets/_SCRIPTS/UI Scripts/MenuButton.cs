using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tomas
{
    public class MenuButton : MonoBehaviour
    {
        public PlayerInputHandler playerInputHandler;

        public void menuButton()
        {
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            Time.timeScale = 1;
            SceneManager.LoadScene("Title Screen");
        }
    }
}

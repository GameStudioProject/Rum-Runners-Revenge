using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tomas
{
    public class RestartButton : MonoBehaviour
    {

        public PlayerInputHandler playerInputHandler;

        public void restartButton()
        {
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

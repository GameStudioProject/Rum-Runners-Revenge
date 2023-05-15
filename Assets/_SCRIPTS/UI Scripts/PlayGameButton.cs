using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tomas
{
    public class PlayGameButton : MonoBehaviour
    {

        public void PlayGame()
        {
            GameObject.Find("UI Audio").GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}

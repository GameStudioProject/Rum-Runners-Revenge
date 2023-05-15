using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class GameOverCheck : MonoBehaviour
    {

        public GameObject gameOverCanvas;
        public GameObject backgroundAudio1;
        public GameObject backgroundAudio2;
        public GameObject deathAudio;

        public bool isDead = false;

        void Update ()
        {
            bool death = PlayerManager.instance.player.Core.GetCoreComponent<DeathComponent>().isDead;

            if (death)
            {   
                isDead = true;
                deathAudio.SetActive(true);
                backgroundAudio1.SetActive(false);
                backgroundAudio2.SetActive(false);
                StartCoroutine("wait");
            }
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(3);
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
        }



    }
}

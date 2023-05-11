using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class GameOverCheck : MonoBehaviour
    {

        public GameObject gameOverCanvas;
        public GameObject backgroundAudio;
        public GameObject deathAudio;

        void Update ()
        {
            bool death = PlayerManager.instance.player.Core.GetCoreComponent<DeathComponent>().isDead;

            if (death)
            {
                deathAudio.SetActive(true);
                backgroundAudio.SetActive(false);
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

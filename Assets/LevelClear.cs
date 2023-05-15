using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Tomas
{
    public class LevelClear : MonoBehaviour
    {

        public GameObject LevelClearCheck;
        public GameObject Level2Music;
        public GameObject Collectible;
        public GameObject Timer;

        public GameObject score;
        public TMP_Text levelClearText;
        public TMP_Text timerText;
        public TMP_Text scoreText;
        public GameObject playerUI;


        void Start()
        {
            score.SetActive(false);
            Time.timeScale = 0;
            playerUI.SetActive(false);
            GameObject.Find("Level Clear Audio").GetComponent<AudioSource>().Play();
            StartCoroutine(Appear());

        }


        IEnumerator Appear()
        {
            yield return new WaitForSecondsRealtime(1);
            levelClearText.text = "LEVEL " + LevelClearCheck.GetComponent<LevelClearCheck>().levelCount.ToString() + " CLEARED";
            yield return new WaitForSecondsRealtime(2);
            timerText.text = Timer.GetComponent<TimerScript>().timeText.text.ToString();
            yield return new WaitForSecondsRealtime(2);
            score.SetActive(true);
            scoreText.text = "x" + Collectible.GetComponent<CollectibleScript>().count;
            yield return new WaitForSecondsRealtime(4);
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
            if (LevelClearCheck.GetComponent<LevelClearCheck>().levelCount == 1)
            {
                Level2Music.SetActive(true);
            }
            PlayerManager.instance.player.PlayerInputHandler.levelScreenClear = false;
            playerUI.SetActive(true);

        }

    }
}

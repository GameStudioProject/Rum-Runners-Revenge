using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tomas
{
    public class TimerScript : MonoBehaviour
    {

        public float startTime = 0;
        public TMP_Text timeText;


        public float t;

        public GameOverCheck GameOverCheck;

        void Update()
        {
            if (GameOverCheck.isDead == false)
            {
                t = Time.timeSinceLevelLoad - startTime;
                string minutes = ((int)t / 60).ToString();
                t = Mathf.Round(t % 60);
                string seconds = t.ToString();
                timeText.text = "Time - " + minutes + ":" + seconds;
            }
        }
    }
}

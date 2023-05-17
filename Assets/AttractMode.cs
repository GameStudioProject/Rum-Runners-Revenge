using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

namespace Tomas
{
    public class AttractMode : MonoBehaviour
    {

        public float targetTime = 15.0f;
        public GameObject Video;
        public VideoPlayer videoPlayer;
        public GameObject Audio;
        public Button Play;


        void Start() 
        {
            videoPlayer.SetDirectAudioMute(0, true);
        }


        void Update()
        {   
            targetTime -= Time.deltaTime;
            if (targetTime <= 0.0f)
            {
                videoPlay();
            }
            else if (Input.anyKey)
            {
                targetTime = 15.0f;
            }

        }

        void videoPlay()
        {
            Debug.Log("yes");
            Video.SetActive(true);
            videoPlayer.Play();
            videoPlayer.SetDirectAudioMute(0, false);
            Audio.SetActive(false);
            if (Input.anyKey)
            {
                targetTime = 15.0f;
                Video.SetActive(false);
                videoPlayer.SetDirectAudioMute(0, true);
                Audio.SetActive(true);
                Play.Select();
            }
        }




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class TutorialPopup : MonoBehaviour
    {

        public GameObject Image;
        public GameObject Canvas;

        public bool tip = false;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerManager.instance.player.PlayerInputHandler.InteractInput)
            {
                if (tip)
                {
                    Canvas.SetActive(true);
                }
                
            }
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            Image.SetActive(true);
            tip = true;
            PlayerManager.instance.player.PlayerInputHandler.canPress = true;
        }
        private void OnTriggerExit2D(Collider2D other) 
        {
            Image.SetActive(false);
            tip = false;
            PlayerManager.instance.player.PlayerInputHandler.canPress = false;
            Canvas.SetActive(false);
        }
    }
}

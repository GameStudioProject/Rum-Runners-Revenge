using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tomas
{
    public class LevelClearCheck : MonoBehaviour
    {

        public GameObject Level1Block;
        public GameObject Level2Block;
        public GameObject Level1Music;
        public GameObject Level2Music;

        public double levelCount = 0;

        public GameObject LevelClearCanvas;
        

        public void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (levelCount < 1)
                {
                    Level1Block.SetActive(true);
                    Level1Music.SetActive(false);

                }
                else if (levelCount < 2)
                {
                    Level2Block.SetActive(true);
                    Level2Music.SetActive(false);
                }


                levelCount += 0.5;
                LevelClearCanvas.SetActive(true);
                LevelClearCanvas.GetComponent<LevelClear>().StartScreen();
                PlayerManager.instance.player.PlayerInputHandler.levelScreenClear = true;
            }
        }

        


    }
}

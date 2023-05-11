using UnityEngine;


    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;
        public PlayerBase player;

        private void Awake()
        {
            if(instance != null)
                Destroy(instance.gameObject);
            else
                instance = this;
        }
    }

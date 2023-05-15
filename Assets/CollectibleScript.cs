using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Tomas
{
    public class CollectibleScript : MonoBehaviour
    {
        
        public TMP_Text collectibleText;
        public double count = 0;

        void Update()
        {
            collectibleText.text = "x" + count;
        }
    }
}

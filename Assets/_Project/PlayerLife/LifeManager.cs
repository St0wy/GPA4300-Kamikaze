using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.PlayerLife
{
    
    public class LifeManager : MonoBehaviour
    {
        [field:SerializeField, ReadOnly]
        public int PlayerLife { get; set; }

        private void Start()
        {
            PlayerLife = 100;
        }

       
    }
}

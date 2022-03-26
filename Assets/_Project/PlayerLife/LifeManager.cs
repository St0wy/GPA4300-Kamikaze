using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.PlayerLife
{
    public class LifeManager : MonoBehaviour
    {
        [field: SerializeField]
        public int PlayerLife { get; set; } = 100;
       
    }
}

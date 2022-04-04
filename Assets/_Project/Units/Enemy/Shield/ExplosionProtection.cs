using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Units.Enemy.Shield
{
    public class ExplosionProtection : MonoBehaviour
    {
        public bool IsEnabled { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            IsEnabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class SynergyWithShield : MonoBehaviour
    {
        private void Start()
        {
            OnSynergy = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Shield"))
            {
                OnSynergy = true;
            }
        }

        public bool OnSynergy { get; set; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    public class BehaviorOnShieldCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("AllyShield"))
            {
                Destroy(other.gameObject);
            }
        }
      
    }
}

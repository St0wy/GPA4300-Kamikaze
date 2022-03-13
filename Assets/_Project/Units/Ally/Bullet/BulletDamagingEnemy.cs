using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Units
{
    public class BulletDamagingEnemy : MonoBehaviour
    {
        private int damage = 8;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Shootable"))
            {
                HealthBehaviour healthBehaviour = other.GetComponent<HealthBehaviour>();
                healthBehaviour.ReduceHealth(damage);
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Units
{
    public class BulletDamagingEnemy : MonoBehaviour
    {
        private int normalDamage = 1;
        private int synergyDamage = 2;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Shootable"))
            {
                SynergyWithShield synergyWithShield = GetComponent<SynergyWithShield>();
                HealthBehaviour healthBehaviour = other.GetComponent<HealthBehaviour>();

                if (synergyWithShield.OnSynergy)
                {
                    //Debug.Log("On Synergy");
                    healthBehaviour.ReduceHealth(synergyDamage);
                }
                else
                {
                    //Debug.Log("Off Synergy");
                    healthBehaviour.ReduceHealth(normalDamage);
                }
               
                Destroy(gameObject);
            }
        }
    }
}

using UnityEngine;

namespace Kamikaze.Units.Enemy.ShieldBreaker
{
    public class BehaviorOnShieldCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("AllyShield"))
            {
                HealthBehaviour healthBehaviour = other.GetComponentInParent<HealthBehaviour>();
                if(healthBehaviour!=null)
                {
                    int damage = healthBehaviour.HealthPoints - 1;
                    healthBehaviour.HealthPoints -= damage;
                }
                Destroy(other.gameObject);
            }
        }
      
    }
}

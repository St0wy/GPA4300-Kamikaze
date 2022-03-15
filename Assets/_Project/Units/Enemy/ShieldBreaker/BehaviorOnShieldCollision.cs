using UnityEngine;

namespace Kamikaze.Units.Enemy.ShieldBreaker
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

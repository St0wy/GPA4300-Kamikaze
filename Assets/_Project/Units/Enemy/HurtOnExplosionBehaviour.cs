using UnityEngine;

namespace Kamikaze.Units.Enemy
{
    /// <summary>
    /// Behaviour to put on the objects that should be damaged by explosions.
    /// </summary>
    [RequireComponent(typeof(HealthBehaviour))]
    public class HurtOnExplosionBehaviour : MonoBehaviour
    {
        private HealthBehaviour healthBehaviour;

        private void Awake()
        {
            healthBehaviour = GetComponent<HealthBehaviour>();
        }

        public void Hurt(int damage)
        {
            healthBehaviour.ReduceHealth(damage);
        }
    }
}
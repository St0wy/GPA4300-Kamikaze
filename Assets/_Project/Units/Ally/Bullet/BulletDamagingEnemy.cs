using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
    [RequireComponent(typeof(SynergyWithShield))]
    public class BulletDamagingEnemy : MonoBehaviour
    {
        [SerializeField] private int normalDamage = 1;
        [SerializeField] private int synergyDamage = 2;

        private SynergyWithShield synergyWithShield;

        private void Awake()
        {
            synergyWithShield = GetComponent<SynergyWithShield>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Shootable")) return;
            
            var healthBehaviour = other.GetComponent<HealthBehaviour>();

            healthBehaviour.ReduceHealth(synergyWithShield.HasSynergy ? synergyDamage : normalDamage);

            Destroy(gameObject);
        }
    }
}

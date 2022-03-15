using Kamikaze.Units.Ally.Freezer;
using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
    [RequireComponent(typeof(BulletBehavior))]
    [RequireComponent(typeof(FreezeBehaviour))]
    public class BulletFreezingEnemy : MonoBehaviour
    {
        private FreezeBehaviour freezeBehaviour;

        private void Awake()
        {
            freezeBehaviour = GetComponent<FreezeBehaviour>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Shootable")) return;

            if (!freezeBehaviour.IsFrozen) return;

            var otherFreeze = other.GetComponent<FreezeBehaviour>();
            if (otherFreeze != null)
            {
                otherFreeze.Freeze();
            }

            Destroy(gameObject);
        }
    }
}
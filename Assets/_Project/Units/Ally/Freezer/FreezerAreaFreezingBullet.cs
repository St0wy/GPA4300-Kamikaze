using Kamikaze.Units.Ally.Bullet;
using UnityEngine;

namespace Kamikaze.Units.Ally.Freezer
{
    public class FreezerAreaFreezingBullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Bullet")) return;

            var bulletBehavior = other.GetComponent<BulletBehavior>();
            if (bulletBehavior != null)
            {
                bulletBehavior.IsFrozen = true;
            }
        }
    }
}
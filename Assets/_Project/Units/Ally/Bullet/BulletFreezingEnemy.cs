using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
    public class BulletFreezingEnemy : MonoBehaviour
    {
        [SerializeField] private float enemyFreezingSpeed = 0.02f;

        private BulletBehavior bulletBehavior;

        private void Awake()
        {
            bulletBehavior = GetComponent<BulletBehavior>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Shootable")) return;

            if (!bulletBehavior.IsFrozen) return;

            var moveOnLaneBehaviour = other.GetComponent<MoveOnLaneBehaviour>();
            if (moveOnLaneBehaviour != null)
            {
                moveOnLaneBehaviour.MoveSpeed = enemyFreezingSpeed;
            }

            Destroy(gameObject);
        }
    }
}
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Enemy
{
    public class DamageOnCollisionBehaviour : MonoBehaviour
    {
        [Tooltip("The tag that this object will damage.")] [Tag] [SerializeField]
        private string tagToDamage = string.Empty;

        [SerializeField] private int damage = 1;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag(tagToDamage)) return;

            var healthBehaviour = collision.gameObject.GetComponent<HealthBehaviour>();
            if (healthBehaviour != null)
            {
                healthBehaviour.ReduceHealth(damage);
            }
        }
    }
}
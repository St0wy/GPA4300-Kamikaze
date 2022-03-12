using UnityEngine;

namespace Kamikaze.Units.Ally.Explosions
{
    /// <summary>
    /// Behaviour to put on objects that should explode on death.
    /// </summary>
    [RequireComponent(typeof(HealthBehaviour))]
    public class ExplodeOnDeathBehaviour : MonoBehaviour
    {
        [SerializeField] private ExplosionManager explosionManager;
        [SerializeField] private ExplosionScriptableObject explosionScriptableObject;

        private HealthBehaviour healthBehaviour;

        private void Awake()
        {
            healthBehaviour = GetComponent<HealthBehaviour>();
            healthBehaviour.OnHurt += OnHurt;
        }

        private void OnDrawGizmosSelected()
        {
            Vector3 position = transform.position;
            Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
            Gizmos.DrawSphere(position, explosionScriptableObject.ExplosionRadius);
            Gizmos.color = new Color(0f, 0f, 1f, 0.1f);
            Gizmos.DrawSphere(position, explosionScriptableObject.MaxDamageMargin);
        }

        private void OnHurt(int healthPoints)
        {
            if (!healthBehaviour.IsAlive)
            {
                Explode();
            }
        }

        [MyBox.ButtonMethod]
        private void Explode()
        {
            explosionManager.TriggerExplosion(transform.position, explosionScriptableObject);
        }
    }
}
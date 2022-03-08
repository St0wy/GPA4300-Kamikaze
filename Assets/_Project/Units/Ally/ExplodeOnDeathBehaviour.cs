using UnityEngine;

namespace Kamikaze.Units.Ally
{
    /// <summary>
    /// Behaviour to put on objects that should explode on death.
    /// </summary>
    [RequireComponent(typeof(HealthBehaviour), typeof(ExplosionBehaviour))]
    public class ExplodeOnDeathBehaviour : MonoBehaviour
    {
        private ExplosionBehaviour explosionBehaviour;
        private HealthBehaviour healthBehaviour;

        private void Awake()
        {
            healthBehaviour = GetComponent<HealthBehaviour>();
            healthBehaviour.OnHurt += OnHurt;
            explosionBehaviour = GetComponent<ExplosionBehaviour>();
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
            // TODO : REMOVE THIS SOON
            GetComponent<MeshRenderer>().enabled = false;

            StartCoroutine(explosionBehaviour.ExplodeCoroutine());
        }
    }
}
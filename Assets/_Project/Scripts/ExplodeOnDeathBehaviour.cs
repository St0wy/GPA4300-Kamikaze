using UnityEngine;

namespace Kamikaze
{
    /// <summary>
    /// Behaviour to put on objects that should explode on death.
    /// </summary>
    [RequireComponent(typeof(HealthBehaviour))]
    public class ExplodeOnDeathBehaviour : MonoBehaviour
    {
        [SerializeField] private ExplosionBehaviour explosionBehaviour;

        private HealthBehaviour healthBehaviour;

        private void Awake()
        {
            healthBehaviour = GetComponent<HealthBehaviour>();
            healthBehaviour.OnHurt += OnHurt;
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

            StartCoroutine(explosionBehaviour.Explode());
        }
    }
}
using System;
using System.Collections;
using Kamikaze.Units.Enemy;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kamikaze.Units.Ally
{
    /// <summary>
    /// Behaviour that handles explosions.
    /// Should be placed on the object where the explosion should happen (not on the explosion prefab).
    /// </summary>
    public class ExplosionBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject explosionObject;

        [Tooltip("Time of the explosion in seconds.")] [SerializeField]
        private float explosionTime = 2f;

        [SerializeField] private float explosionRadius = 1f;

        [FormerlySerializedAs("explosionDamage")] [SerializeField]
        private int maxExplosionDamage = 20;

        [Tooltip("The max number of colliders that an explosion can have.")] [SerializeField]
        private int maxColliders = 20;

        private Collider[] explosionColliders;

        private void Awake()
        {
            explosionColliders = new Collider[maxColliders];
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
            Gizmos.DrawSphere(transform.position, explosionRadius);
        }

        /// <summary>
        /// Explosion coroutine.
        /// Shows and hide the explosion effect and applies the damage.
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// <code>StartCoroutine(explosionBehaviour.Explode());</code>
        /// </example>
        public IEnumerator ExplodeCoroutine()
        {
            Vector3 position = transform.position;

            // Move and show the explosion
            explosionObject.transform.position = position;
            explosionObject.SetActive(true);

            // Hurt with the explosion
            int size = Physics.OverlapSphereNonAlloc(position, explosionRadius, explosionColliders);

            for (var i = 0; i < size; i++)
            {
                var hurtOnExplosionBehaviour = explosionColliders[i].GetComponent<HurtOnExplosionBehaviour>();
                if (hurtOnExplosionBehaviour != null)
                {
                    ApplyExplosionDamage(hurtOnExplosionBehaviour);
                }
            }

            // Wait and hide the explosion            
            yield return new WaitForSeconds(explosionTime);
            explosionObject.SetActive(false);
        }

        private void ApplyExplosionDamage(HurtOnExplosionBehaviour hurtOnExplosionBehaviour)
        {
            float distance = Vector3.Distance(hurtOnExplosionBehaviour.transform.position, transform.position);

            // Damage equation so that the damages are lowered the furthest the explosion happens
            float damage =
                (maxExplosionDamage * explosionRadius * explosionRadius - maxExplosionDamage * distance) /
                (explosionRadius * explosionRadius);
            hurtOnExplosionBehaviour.Hurt((int) damage);
        }
    }
}
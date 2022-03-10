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

        [Tooltip("A margin at which the damage calculation will keep the max damages")] [SerializeField]
        private float maxDamageMargin = 2f;

        private Collider[] explosionColliders;

        private void Awake()
        {
            explosionColliders = new Collider[maxColliders];
        }

        private void OnDrawGizmosSelected()
        {
            Vector3 position = transform.position;
            Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
            Gizmos.DrawSphere(position, explosionRadius);
            Gizmos.color = new Color(0f, 0f, 1f, 0.1f);
            Gizmos.DrawSphere(position, maxDamageMargin);
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
            var damage = 0f;

            if (distance < maxDamageMargin)
            {
                damage = maxExplosionDamage;
            }
            else
            {
                // Damage equation so that the damages are lowered the furthest the explosion happens
                damage =
                    (maxExplosionDamage * explosionRadius * explosionRadius - maxExplosionDamage * distance) /
                    (explosionRadius * explosionRadius);
                damage = Mathf.Clamp(damage, 0, maxExplosionDamage);
            }

            hurtOnExplosionBehaviour.Hurt((int) damage);
        }
    }
}
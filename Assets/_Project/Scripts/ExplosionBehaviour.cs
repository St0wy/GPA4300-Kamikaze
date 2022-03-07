using System;
using System.Collections;
using UnityEngine;

namespace Kamikaze
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
        [SerializeField] private int explosionDamage = 20;

        [Tooltip("The max number of colliders that an explosion can have.")]
        [SerializeField] private int maxCollider = 10;

        private Collider[] explosionColliders;

        private void Awake()
        {
            explosionColliders = new Collider[maxCollider];
        }

        /// <summary>
        /// Explosion coroutine.
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// <code>StartCoroutine(explosionBehaviour.Explode());</code>
        /// </example>
        public IEnumerator Explode()
        {
            Vector3 position = transform.position;
            
            // Move and show the explosion
            explosionObject.transform.position = position;
            explosionObject.SetActive(true);

            // Hurt with the explosion
            int size = Physics.OverlapSphereNonAlloc(position, explosionRadius, explosionColliders);

            for (var i = 0; i < size; i++)
            {
                Collider col = explosionColliders[i];
                var hurtOnExplosionBehaviour = col.GetComponent<HurtOnExplosionBehaviour>();
                if (hurtOnExplosionBehaviour != null)
                {
                    hurtOnExplosionBehaviour.Hurt(explosionDamage);
                }
            }

            // Wait and hide the explosion            
            yield return new WaitForSeconds(explosionTime);
            explosionObject.SetActive(false);
        }
    }
}
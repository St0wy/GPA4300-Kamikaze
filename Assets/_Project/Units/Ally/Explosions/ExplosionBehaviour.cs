using System;
using UnityEngine;

namespace Kamikaze.Units.Ally.Explosions
{
    /// <summary>
    /// Behaviour that handles explosions.
    /// Should be placed on the object where the explosion should happen (not on the explosion prefab).
    /// </summary>
    [RequireComponent(typeof(ParticleSystem))]
    public class ExplosionBehaviour : MonoBehaviour
    {
        private float disableTimer;
        private ParticleSystem particleSystem;

        public ExplosionScriptableObject ScriptableObject { get; set; }
        public ExplosionManager ExplosionManager { get; set; }

        private void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            disableTimer -= Time.deltaTime;

            if (disableTimer <= 0f)
            {
                ExplosionManager.TakeBack(this);
            }
        }

        public void Initialize(Vector3 position, ExplosionScriptableObject explosionScriptable)
        {
            transform.position = position;
            disableTimer = explosionScriptable.ExplosionTime;
            ScriptableObject = explosionScriptable;
            gameObject.SetActive(true);
            particleSystem.Play(true);
        }
    }
}
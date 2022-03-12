﻿using UnityEngine;

namespace Kamikaze.Units.Ally.Explosions
{
    /// <summary>
    /// Behaviour that handles explosions.
    /// Should be placed on the object where the explosion should happen (not on the explosion prefab).
    /// </summary>
    public class ExplosionBehaviour : MonoBehaviour
    {
        private float disableTimer;

        public ExplosionScriptableObject ScriptableObject { get; set; }
        public ExplosionManager ExplosionManager { get; set; }

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
        }
    }
}
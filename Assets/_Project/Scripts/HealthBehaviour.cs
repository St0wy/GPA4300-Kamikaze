using System;
using MyBox;
using UnityEngine;

namespace Kamikaze
{
    /// <summary>
    /// Script to put on game objects that must have health like the player or enemies.
    /// </summary>
    public class HealthBehaviour : MonoBehaviour
    {
        public delegate void HurtCallback(int healthPoints);

        [SerializeField] private bool destroyWhenKilled = true;

        [ConditionalField(nameof(destroyWhenKilled))] [SerializeField]
        private float destroyTime;

        public HurtCallback OnHurt { get; set; }
        public bool IsAlive { get; private set; }
        public int HealthPoints { get; private set; }

        public int MaxHealthPoints { get; set; } = 15;

        private void Awake()
        {
            IsAlive = true;
        }

        private void Start()
        {
            // Set the health points to MaxHealthPoints
            // Max health points should be set in an awake function
            HealthPoints = MaxHealthPoints;
        }

        /// <summary>
        ///     Reduces the health of the game object and kills it if health = 0.
        /// </summary>
        /// <param name="amount">The amount of health to subtract. Defaults to 1.</param>
        public void ReduceHealth(int amount = 1)
        {
            HealthPoints -= amount;

            if (HealthPoints <= 0)
            {
                IsAlive = false;
            }

            OnHurt?.Invoke(HealthPoints);

            if (!IsAlive && destroyWhenKilled)
            {
                Destroy(gameObject, destroyTime);
            }
        }
    }
}
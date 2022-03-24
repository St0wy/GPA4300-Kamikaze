using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Units
{
    [RequireComponent(typeof(HealthBehaviour))]
    public class LinkEnemyWaveSpawner : MonoBehaviour
    {
        public WaveSpawner WaveSpawner { get; set; }
        private HealthBehaviour healthBehaviour;

        private void Awake()
        {
            healthBehaviour = GetComponent<HealthBehaviour>();
            healthBehaviour.OnHurt += OnHurt;
        }

        private void OnHurt(int healthPoints)
        {
            if(!healthBehaviour.IsAlive)
            {
                WaveSpawner.CurrentWave.totalEnemies--;
            }
        }
    }
}

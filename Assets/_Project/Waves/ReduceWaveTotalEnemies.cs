using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.Units;
namespace Kamikaze.Waves
{

    public class ReduceWaveTotalEnemies : MonoBehaviour
    {
        private LinkEnemyWaveSpawner linkEnemyWaveSpawner;
        private HealthBehaviour healthBehaviour;
        private LaneUnitBehaviour laneUnitBehaviour;

        // Start is called before the first frame update
        void Start()
        {
            laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
            linkEnemyWaveSpawner = GetComponent<LinkEnemyWaveSpawner>();
            healthBehaviour = GetComponent<HealthBehaviour>();
            healthBehaviour.OnHurt += OnHurt;
        }

        private void Update()
        {
            if(laneUnitBehaviour.Position <= 0f)
            {
                linkEnemyWaveSpawner.WaveSpawner.CurrentWave.totalEnemies--;
                Destroy(gameObject);
            }
        }

        private void OnHurt(int healthPoints)
        {        
            if (!healthBehaviour.IsAlive) linkEnemyWaveSpawner.WaveSpawner.CurrentWave.totalEnemies--;
        }
    }
}

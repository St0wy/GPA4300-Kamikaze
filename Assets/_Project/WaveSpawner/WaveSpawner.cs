using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kamikaze.Lanes;
using UnityEngine.UI;

namespace Kamikaze.Units
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public int totalEnemies;
        public WaveState waveState;
        public SpawnerData[] spawners;
    }

    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private LanesManager lanesManager;
        private int currentWaveIndex;
        [SerializeField] private float waitTime;
        [SerializeField] private Wave[] waves;


        private void Start()
        {
            foreach (var wave in waves)
            {
                wave.waveState = WaveState.Inactive;

                foreach (var spawner in wave.spawners)
                {
                    spawner.maxEnemies = spawner.noOfEnemiesToSpawn;
                    if (spawner.maxEnemies > 0)
                    {
                        wave.totalEnemies += spawner.maxEnemies;
                    }
                }
            }
        }
        private void Update()
        {
            CurrentWave = waves[currentWaveIndex];
            switch (CurrentWave.waveState)
            {
                case WaveState.Active:
                    SpawnWave();
                    if (CurrentWave.totalEnemies <= 0)
                    {
                        CurrentWave.waveState = WaveState.Inactive;
                        if (currentWaveIndex + 1 < waves.Length)
                        {
                            currentWaveIndex++;
                            StartCoroutine(StartNextWaveCoroutine());
                        }
                    }
                    break;

                case WaveState.Inactive:
                    if (CurrentWave.totalEnemies <= 0)
                    {
                        Debug.Log("level completed!");
                    }
                    break;

            }


        }

        private void SpawnWave()
        {
            foreach (var spawner in CurrentWave.spawners)
            {
                if (spawner.canSpawnEnemy && spawner.nextSpawnTime < Time.time)
                {
                    //Instantiates random enemy types
                    int enemyTypeIndex = Random.Range(0, spawner.typesOfEnemies.Length);
                    GameObject enemyType = spawner.typesOfEnemies[enemyTypeIndex].gameObject;
                    GameObject enemy = Instantiate(enemyType, transform.position, Quaternion.identity);

                    //Assign its position
                    LaneUnitBehaviour enemyLaneUnitBehavior = enemy.GetComponent<LaneUnitBehaviour>();
                    enemyLaneUnitBehavior.LaneId = spawner.laneId;
                    enemyLaneUnitBehavior.LanesManager = lanesManager;

                    //Link to wave spawner
                    LinkEnemyWaveSpawner linkEnemyWaveSpawner = enemy.GetComponent<LinkEnemyWaveSpawner>();
                    linkEnemyWaveSpawner.WaveSpawner = this;

                    spawner.noOfEnemiesToSpawn--;
                    spawner.nextSpawnTime = Time.time + spawner.spawnInterval;
                    if (spawner.noOfEnemiesToSpawn == 0)
                    {
                        spawner.canSpawnEnemy = false;
                    }

                }
            }
        }



        public IEnumerator StartNextWaveCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            CurrentWave.waveState = WaveState.Active;
        }

        public Wave CurrentWave { get; set; }
    }
}

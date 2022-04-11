using System;
using System.Collections;
using Kamikaze.Lanes;
using Kamikaze.LevelSelect;
using Kamikaze.MonetarySystem;
using Kamikaze.PlayerLife;
using Kamikaze.Units;
using Kamikaze.Units.Ally;
using MyBox;
using StowyTools.Logger;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kamikaze.Waves
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private LevelsManagerScriptableObject levelsManager;
        [SerializeField] private LanesManager lanesManager;
        [SerializeField] private LifeManager lifeManager;
        [SerializeField] private float waitTime;
        [SerializeField] private Wave[] waves;
        [SerializeField] private GameObject winText;

        [Tooltip("The time it takes to load the level menu after completing the level.")]
        [SerializeField]
        private float timeToLoadLevelMenu;

        [SerializeField] private SceneReference levelMenuScene;
        [SerializeField] private MoneyScriptableObject money;
        [SerializeField] private DropManager dropManager;

        private int currentWaveIndex;
        private bool isLevelOver;

        public Wave[] Waves => waves;

        public Wave CurrentWave => Waves[currentWaveIndex];

        private void Start()
        {
            for (var i = 0; i < Waves.Length; i++)
            {
                Wave wave = Waves[i];
                wave.waveState = currentWaveIndex == i ? WaveState.Active : WaveState.Inactive;

                foreach (SpawnerData spawner in wave.spawners)
                {
                    spawner.maxEnemies = spawner.noOfEnemiesToSpawn;
                    if (spawner.maxEnemies > 0) wave.totalEnemies += spawner.maxEnemies;
                }
            }
        }

        private void Update()
        {
            if (!isLevelOver) UpdateWaveState();
        }

        private void UpdateWaveState()
        {
            switch (CurrentWave.waveState)
            {
                case WaveState.Active:
                    SpawnWave();
                    if (CurrentWave.totalEnemies <= 0)
                    {
                        CurrentWave.waveState = WaveState.Inactive;
                        if (currentWaveIndex + 1 < Waves.Length)
                        {
                            currentWaveIndex++;
                            StartCoroutine(StartNextWaveCoroutine());
                        }
                    }

                    break;
                case WaveState.Inactive:
                    if (CurrentWave.totalEnemies <= 0) CompleteLevel();

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CompleteLevel()
        {
            this.Log("level completed!");
            isLevelOver = true;
            winText.SetActive(true);

            // Pickup all the remaining allies
            var allies = FindObjectsOfType<BackInInventoryBehaviour>();
            allies.ForEach(ally => ally.ReturnInInventory());

            // Kill all enemies
            var enemies = FindObjectsOfType<HealthBehaviour>();
            enemies.ForEach(enemy => enemy.Kill());

            // Pickup the gems
            var gems = FindObjectsOfType<DropBehaviour>();
            gems.ForEach(gem => dropManager.PickupGem(gem));

            // Add the gems to the global money
            money.AddGems(dropManager);

            // Stop the placement of units
            foreach (Lane lane in lanesManager.Lanes)
            {
                lane.tag = "Lane";
            }

            // Set this level to done
            levelsManager.FinishCurrentLevel();

            StartCoroutine(LoadLevelMenuCoroutine());
        }

        private void SpawnWave()
        {
            foreach (SpawnerData spawner in CurrentWave.spawners)
            {
                if (!spawner.canSpawnEnemy || !(spawner.nextSpawnTime < Time.time)) continue;

                //Instantiates random enemy types
                int enemyTypeIndex = Random.Range(0, spawner.typesOfEnemies.Length);
                GameObject enemyType = spawner.typesOfEnemies[enemyTypeIndex].gameObject;
                GameObject enemy = Instantiate(enemyType, transform.position, Quaternion.identity);

                //Assign its position
                var enemyLaneUnitBehavior = enemy.GetComponent<LaneUnitBehaviour>();
                enemyLaneUnitBehavior.LaneId = spawner.laneId;
                enemyLaneUnitBehavior.LanesManager = lanesManager;

                //Links to wave spawner
                var linkEnemyWaveSpawner = enemy.GetComponent<LinkEnemyWaveSpawner>();
                linkEnemyWaveSpawner.WaveSpawner = this;

                //Links to life manager
                var reducePlayerLife = enemy.GetComponent<ReducePlayerLife>();
                reducePlayerLife.LifeManager = lifeManager;

                // Link wave id to ReduceWaveTotalEnemies
                var reduceWaveTotalEnemies = enemy.GetComponent<ReduceWaveTotalEnemies>();
                reduceWaveTotalEnemies.WaveId = currentWaveIndex;

                spawner.noOfEnemiesToSpawn--;
                spawner.nextSpawnTime = Time.time + spawner.spawnInterval;
                if (spawner.noOfEnemiesToSpawn == 0) spawner.canSpawnEnemy = false;
            }
        }

        public IEnumerator StartNextWaveCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            CurrentWave.waveState = WaveState.Active;
        }

        public IEnumerator LoadLevelMenuCoroutine()
        {
            yield return new WaitForSeconds(timeToLoadLevelMenu);
            levelMenuScene.LoadScene();
        }
    }
}
using System;
using System.Collections;
using Kamikaze.Lanes;
using Kamikaze.Units;
using UnityEngine;
using Random = UnityEngine.Random;
using Kamikaze.PlayerLife;

namespace Kamikaze.Waves
{
	public class WaveSpawner : MonoBehaviour
	{
		[SerializeField] private LanesManager lanesManager;
		[SerializeField] private LifeManager lifeManager;
		[SerializeField] private float waitTime;
		[SerializeField] private Wave[] waves;
		private int currentWaveIndex;

		public Wave CurrentWave => waves[currentWaveIndex];

		private void Start()
		{
			for (var i = 0; i < waves.Length; i++)
			{
				Wave wave = waves[i];
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
					if (CurrentWave.totalEnemies <= 0) Debug.Log("level completed!");
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
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

				// Link to wave spawner
				var linkEnemyWaveSpawner = enemy.GetComponent<LinkEnemyWaveSpawner>();
				linkEnemyWaveSpawner.WaveSpawner = this;

				// Link to life manager
				var reducePlayerLife = enemy.GetComponent<ReducePlayerLife>();
				reducePlayerLife.LifeManager = lifeManager;

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
	}
}
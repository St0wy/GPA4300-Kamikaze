using System;
using UnityEngine;

namespace Kamikaze.WaveSpawner
{
	[Serializable]
	public class SpawnerData
	{
		public string spawnerName;
		public int noOfEnemiesToSpawn;
		public int maxEnemies;
		public int laneId;
		[HideInInspector] public float nextSpawnTime;
		public float spawnInterval;
		public bool canSpawnEnemy;
		public GameObject[] typesOfEnemies;
	}
}
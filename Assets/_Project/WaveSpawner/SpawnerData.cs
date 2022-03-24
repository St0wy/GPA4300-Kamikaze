using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze
{
    [System.Serializable]
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

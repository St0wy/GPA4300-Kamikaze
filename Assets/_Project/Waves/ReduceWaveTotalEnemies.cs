using UnityEngine;
using Kamikaze.Units;

namespace Kamikaze.Waves
{
	public class ReduceWaveTotalEnemies : MonoBehaviour
	{
		private LinkEnemyWaveSpawner linkEnemyWaveSpawner;
		private HealthBehaviour healthBehaviour;
		private LaneUnitBehaviour laneUnitBehaviour;
		
		public int WaveId { get; set; }

		private void Awake()
		{
			laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
			linkEnemyWaveSpawner = GetComponent<LinkEnemyWaveSpawner>();
			healthBehaviour = GetComponent<HealthBehaviour>();
			healthBehaviour.OnHurt += OnHurt;
		}

		private void Update()
		{
			if (!(laneUnitBehaviour.Position <= 0)) return;

			linkEnemyWaveSpawner.WaveSpawner.Waves[WaveId].totalEnemies--;
			Destroy(gameObject);
		}

		private void OnHurt(int healthPoints)
		{
			if (!healthBehaviour.IsAlive) linkEnemyWaveSpawner.WaveSpawner.CurrentWave.totalEnemies--;
		}
	}
}
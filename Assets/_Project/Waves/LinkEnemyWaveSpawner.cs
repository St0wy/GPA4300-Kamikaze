using Kamikaze.Units;
using UnityEngine;

namespace Kamikaze.Waves
{
	[RequireComponent(typeof(HealthBehaviour))]
	public class LinkEnemyWaveSpawner : MonoBehaviour
	{
		private HealthBehaviour healthBehaviour;
		public WaveSpawner WaveSpawner { get; set; }

		private void Awake()
		{
			healthBehaviour = GetComponent<HealthBehaviour>();
			healthBehaviour.OnHurt += OnHurt;
		}

		private void OnHurt(int healthPoints)
		{
			if (!healthBehaviour.IsAlive) WaveSpawner.CurrentWave.totalEnemies--;
		}
	}
}
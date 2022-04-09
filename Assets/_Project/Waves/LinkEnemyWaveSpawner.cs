using Kamikaze.Units;
using MyBox;
using UnityEngine;

namespace Kamikaze.Waves
{
	[RequireComponent(typeof(HealthBehaviour))]
	public class LinkEnemyWaveSpawner : MonoBehaviour
	{
		[field: SerializeField]
		[field: ReadOnly]
		public WaveSpawner WaveSpawner { get; set; }
	}
}
using System;

namespace Kamikaze.WaveSpawner
{
	[Serializable]
	public class Wave
	{
		public string waveName;
		public int totalEnemies;
		public WaveState waveState;
		public SpawnerData[] spawners;
	}
}
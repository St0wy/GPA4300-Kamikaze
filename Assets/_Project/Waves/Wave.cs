using System;

namespace Kamikaze.Waves
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
using UnityEngine;

namespace Kamikaze.Units.Enemy.Shield
{
	public class ExplosionProtection : MonoBehaviour
	{
		public bool IsProtected { get; set; }

		private void Start()
		{
			IsProtected = true;
		}
	}
}
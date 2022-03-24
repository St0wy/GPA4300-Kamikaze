using UnityEngine;

namespace Kamikaze.Units.Enemy.Shield
{
	public class BulletProtection : MonoBehaviour
	{
		private int protection = 10;

		private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("AllyBullet")) return;
			DecrementProtection();
			Destroy(other.gameObject);
		}

		private void DecrementProtection()
		{
			protection--;
			if (protection <= 0) Destroy(gameObject);
		}
	}
}
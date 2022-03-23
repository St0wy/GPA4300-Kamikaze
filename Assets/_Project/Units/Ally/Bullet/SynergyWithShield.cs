using Kamikaze.Units.Ally.Shield;
using UnityEngine;

namespace Kamikaze.Units.Ally.Bullet
{
	public class SynergyWithShield : MonoBehaviour
	{
		private void Start()
		{
			HasSynergy = false;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Ally")) return;

			var shieldTroopBehavior = other.GetComponent<ShieldTroopBehavior>();
			if (shieldTroopBehavior != null)
			{
				HasSynergy = true;
			}
		}

		public bool HasSynergy { get; set; }
	}
}
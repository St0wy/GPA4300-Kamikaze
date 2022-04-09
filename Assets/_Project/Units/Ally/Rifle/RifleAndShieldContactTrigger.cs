using Kamikaze.Units.Ally.Shield;
using UnityEngine;

namespace Kamikaze.Units.Ally.Rifle
{
	public class RifleAndShieldContactTrigger : MonoBehaviour
	{
		private RifleAndShieldContactBehavior rifleAndShieldContactBehavior;
		private ShieldTroopBehavior shieldTroopBehavior;

		private void Awake()
		{
			rifleAndShieldContactBehavior = GetComponent<RifleAndShieldContactBehavior>();
		}

		private void OnCollisionStay(Collision collision)
		{
			shieldTroopBehavior = collision.transform.GetComponent<ShieldTroopBehavior>();
			if (shieldTroopBehavior == null || shieldTroopBehavior.State != ShieldState.Shielding) return;

			rifleAndShieldContactBehavior.BlockRifle = true;
			shieldTroopBehavior.RifleAndShieldContactBehavior = rifleAndShieldContactBehavior;
		}
	}
}
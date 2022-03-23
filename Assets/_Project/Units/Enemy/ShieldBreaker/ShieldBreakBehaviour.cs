using Kamikaze.Units.Ally.Shield;
using StowyTools.Logger;
using UnityEngine;

namespace Kamikaze.Units.Enemy.ShieldBreaker
{
	public class ShieldBreakBehaviour : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision)
		{
			var shieldTroopBehavior = collision.gameObject.GetComponent<ShieldTroopBehavior>();
			if (shieldTroopBehavior == null) return;
			
			shieldTroopBehavior.BreakShield();
		}
	}
}
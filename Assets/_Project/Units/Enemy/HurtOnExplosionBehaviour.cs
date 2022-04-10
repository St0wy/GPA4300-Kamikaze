using Kamikaze.Units.Ally.Freezer;
using Kamikaze.Units.Enemy.Shield;
using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	/// <summary>
	///     Behaviour to put on the objects that should be damaged by explosions.
	/// </summary>
	[RequireComponent(typeof(HealthBehaviour))]
	public class HurtOnExplosionBehaviour : MonoBehaviour
	{
		private HealthBehaviour healthBehaviour;

		private void Awake()
		{
			healthBehaviour = GetComponent<HealthBehaviour>();
		}

		public void Hurt(int damage, int bonus = 40)
		{
			var realDamage = 0;
			var freezeStuckBehaviour = GetComponent<FreezeStuckBehaviour>();
			var explosionProtection = GetComponent<ExplosionProtection>();
			if (explosionProtection != null)
			{
				if (!explosionProtection.IsProtected) realDamage = damage + bonus;
			}
			else
			{
				if (freezeStuckBehaviour != null)
				{
					if (freezeStuckBehaviour.IsStuck)
						realDamage = damage + bonus;
					else
						realDamage = damage;
				}
			}

			healthBehaviour.ReduceHealth(realDamage);
		}
	}
}
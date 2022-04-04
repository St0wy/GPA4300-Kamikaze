using UnityEngine;
using Kamikaze.Units.Ally.Freezer;

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

		public void Hurt(int damage, int bonus = 20)
		{
			int realDamage = 0;
			FreezeStuckBehaviour freezeStuckBehaviour = GetComponent<FreezeStuckBehaviour>();
			if(freezeStuckBehaviour!=null)
            {
				if(freezeStuckBehaviour.IsStuck)
                {
					realDamage = damage + bonus;
					Debug.Log("stuck damage " + realDamage);
                }
				else
				{
					
					realDamage = damage;
					Debug.Log("normal damage " + realDamage);
				}
			}
       

			healthBehaviour.ReduceHealth(realDamage);		
		}
	}
}
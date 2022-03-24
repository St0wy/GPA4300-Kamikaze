using Kamikaze.Units.Ally.Explosions;
using UnityEngine;

namespace Kamikaze.Units.Ally.Freezer
{
	[RequireComponent(typeof(ExplodeOnDeathBehaviour))]
	public class StuckOnExplosionBehaviour : MonoBehaviour
	{
		private ExplodeOnDeathBehaviour explodeOnDeathBehaviour;

		private void Awake()
		{
			explodeOnDeathBehaviour = GetComponent<ExplodeOnDeathBehaviour>();
			explodeOnDeathBehaviour.ExplosionEvent += StuckExplosion;
		}

		private static void StuckExplosion(Collider col)
		{
			var colStuckComponent = col.GetComponent<FreezeStuckBehaviour>();
			if (colStuckComponent != null) colStuckComponent.Stuck();
		}
	}
}
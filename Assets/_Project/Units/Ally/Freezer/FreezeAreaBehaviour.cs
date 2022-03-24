using UnityEngine;

namespace Kamikaze.Units.Ally.Freezer
{
	public class FreezeAreaBehaviour : MonoBehaviour
	{
		private void OnTriggerStay(Collider other)
		{
			var freezeBehaviour = other.GetComponent<FreezeBehaviour>();
			if (freezeBehaviour == null) return;

			if (!freezeBehaviour.IsFrozen)
				freezeBehaviour.Freeze();
		}
	}
}
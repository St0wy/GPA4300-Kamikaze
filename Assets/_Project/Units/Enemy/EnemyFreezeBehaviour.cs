using Kamikaze.Units.Ally.Freezer;
using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	[RequireComponent(typeof(FreezeBehaviour))]
	[RequireComponent(typeof(MoveOnLaneBehaviour))]
	public class EnemyFreezeBehaviour : MonoBehaviour
	{
		[SerializeField] private float frozenSpeed = 0.02f;
		private float baseSpeed;
		private FreezeBehaviour freezeBehaviour;
		private FreezeStuckBehaviour freezeStuckBehaviour;

		private MoveOnLaneBehaviour moveOnLaneBehaviour;

		private void Awake()
		{
			moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
			baseSpeed = moveOnLaneBehaviour.MoveSpeed;

			freezeBehaviour = GetComponent<FreezeBehaviour>();

			if (freezeBehaviour == null) return;
			freezeBehaviour.OnFreeze += OnFreeze;
			freezeBehaviour.OnUnFreeze += OnUnFreeze;

			freezeStuckBehaviour = GetComponent<FreezeStuckBehaviour>();
		}

		private void OnFreeze()
		{
			if (freezeStuckBehaviour != null && !freezeStuckBehaviour.IsStuck)
				moveOnLaneBehaviour.MoveSpeed = frozenSpeed;
		}

		private void OnUnFreeze()
		{
			if (freezeStuckBehaviour != null && !freezeStuckBehaviour.IsStuck)
				moveOnLaneBehaviour.MoveSpeed = baseSpeed;
		}
	}
}
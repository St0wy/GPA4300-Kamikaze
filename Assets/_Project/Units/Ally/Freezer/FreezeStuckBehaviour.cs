using System.Collections;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Ally.Freezer
{
	[RequireComponent(typeof(MoveOnLaneBehaviour))]
	public class FreezeStuckBehaviour : MonoBehaviour
	{
		[SerializeField] private float stuckTime = 1.5f;

		private MoveOnLaneBehaviour moveOnLaneBehaviour;
		private float baseSpeed;

		[field: ReadOnly, SerializeField] public bool IsStuck { get; private set; }

		private void Awake()
		{
			moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
			baseSpeed = moveOnLaneBehaviour.MoveSpeed;
		}

		private void Update()
		{
			if (IsStuck)
			{
				moveOnLaneBehaviour.MoveSpeed = 0f;
			}
		}

		public void Stuck()
		{
			moveOnLaneBehaviour.MoveSpeed = 0f;
			IsStuck = true;
			StartCoroutine(UnStuckCoroutine());
		}

		private IEnumerator UnStuckCoroutine()
		{
			yield return new WaitForSeconds(stuckTime);
			moveOnLaneBehaviour.MoveSpeed = baseSpeed;
			IsStuck = false;
		}
	}
}
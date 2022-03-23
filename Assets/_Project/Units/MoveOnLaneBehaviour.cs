using MyBox;
using UnityEngine;

namespace Kamikaze.Units
{
	/// <summary>
	/// Makes a unit move on the lane with a specified speed and direction.
	/// </summary>
	[RequireComponent(typeof(LaneUnitBehaviour))]
	public class MoveOnLaneBehaviour : MonoBehaviour
	{
		[SerializeField] private MoveDirection moveDirection = MoveDirection.Right;

		private LaneUnitBehaviour laneUnitBehaviour;

		[field: Tooltip("Speed in unit/second of the unit."), ReadOnly, SerializeField]
		public float MoveSpeed { get; set; } = 0.1f;

		public MoveDirection Direction
		{
			get => moveDirection;
			set => moveDirection = value;
		}

		private void Awake()
		{
			laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
		}

		private void Update()
		{
			float moveModifier = Direction == MoveDirection.Left ? 1 : -1;
			float move = MoveSpeed * moveModifier;

			laneUnitBehaviour.Position -= move * Time.deltaTime;
		}
	}
}
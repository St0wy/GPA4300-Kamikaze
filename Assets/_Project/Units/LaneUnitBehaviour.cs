using Kamikaze.Lanes;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units
{
	/// <summary>
	/// MonoBehaviour responsible for placing an Unit on a lane.
	/// </summary>
	public class LaneUnitBehaviour : MonoBehaviour
	{
		[Tooltip("Position of the Unit on the lane from 0 to 1 where 0 = on the left and 1 = on the right.")]
		[Range(0, 1)]
		[SerializeField]
		private float position;

		[field: SerializeField] public LanesManager LanesManager { get; set; }

		[field: Tooltip("The id of the lane this unit should be on. Defined in the lanes manager.")]
		[field: DefinedValues(0, 1, 2, 3, 4)]
		[field: SerializeField]
		public int LaneId { get; set; }

		/// <summary>
		/// Gets or sets the position of the unit.
		/// The setter is clamped between 0 and 1.
		/// </summary>
		public float Position
		{
			get => position;
			set => position = Mathf.Clamp01(value);
		}


		private void Update()
		{
			// Get the lane this unit should be placed on.
			Lane lane = LanesManager.Lanes[LaneId];

			// Set the position of this unit by lerp ing between start pos and end pos.
			transform.position = Vector3.Lerp(lane.StartPos, lane.EndPos, position);
		}
	}
}
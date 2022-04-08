using UnityEngine;

namespace Kamikaze.Lanes
{
	/// <summary>
	///     Class that represents a lane.
	/// </summary>
	public class Lane : MonoBehaviour
	{
		[SerializeField] private Transform startPos;
		[SerializeField] private Transform endPos;

		/// <summary>
		///     Gets the start position of the lane.
		/// </summary>
		public Vector3 StartPos => startPos.position;

		/// <summary>
		///     Gets the end position of the lane.
		/// </summary>
		public Vector3 EndPos => endPos.position;

		[field: SerializeField] public int Id { get; set; }

		/// <summary>
		///     Gets the position in the world from a relative position in the lane.
		/// </summary>
		/// <param name="pos">The position in the lane where 0 = StartPos and 1 = EndPos.</param>
		/// <returns>The position in the world.</returns>
		public Vector3 GetWorldPositionOnLane(float pos)
		{
			return Vector3.Lerp(StartPos, EndPos, pos);
		}

		/// <summary>
		///     Gets the position on a lane from a position in the world.
		/// </summary>
		/// <param name="pos">Position in the world.</param>
		/// <returns>The position on the lane where 0 = StartPos and 1 = EndPos.</returns>
		public float GetLanePositionFromWorld(Vector3 pos)
		{
			return VectorUtils.InverseLerp(StartPos, EndPos, pos);
		}

		
	}
}
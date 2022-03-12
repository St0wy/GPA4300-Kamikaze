using MyBox;
using UnityEngine;

namespace Kamikaze.Units
{
    /// <summary>
    /// MonoBehaviour responsible for placing an Unit on a lane.
    /// </summary>
    public class LaneUnitBehaviour : MonoBehaviour
    {
        [SerializeField] private LanesManager lanesManager;

        [Tooltip("The id of the lane this unit should be on. Defined in the lanes manager.")]
        [DefinedValues(0, 1, 2, 3, 4)]
        [SerializeField]
        private int laneId;

        [Tooltip("Position of the Unit on the lane from 0 to 1 where 0 = on the left and 1 = on the right.")]
        [Range(0, 1)]
        [SerializeField]
        private float position;

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
            Lane lane = lanesManager.Lanes[laneId];

            // Set the position of this unit by lerp ing between start pos and end pos.
            transform.position = Vector3.Lerp(lane.StartPos, lane.EndPos, position);
        }
    }
}
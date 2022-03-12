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

        [field: Tooltip("Speed in unit/second of the unit.")]
        [field: ReadOnly]
        public float MoveSpeed { get; set; } = 0.1f;
        public void SetMoveDirection(MoveDirection newMoveDirection)
        {
            moveDirection = newMoveDirection;
        }


        private void Awake()
        {
            laneUnitBehaviour = GetComponent<LaneUnitBehaviour>();
        }

        private void Update()
        {
            float moveModifier = moveDirection == MoveDirection.Left ? 1 : -1;
            float move = MoveSpeed * moveModifier;
            
            if(moveDirection != MoveDirection.Nowhere)
            {
                unitBehaviour.Position -= move * Time.deltaTime;
            } 
        }
    }
}
using MyBox;
using UnityEngine;

namespace Kamikaze.Units
{
    /// <summary>
    /// Makes a unit move on the lane with a specified speed and direction.
    /// </summary>
    [RequireComponent(typeof(UnitBehaviour))]
    public class MoveOnLaneBehaviour : MonoBehaviour
    {
        [SerializeField] private MoveDirection moveDirection = MoveDirection.Right;

        private UnitBehaviour unitBehaviour;

        [field: Tooltip("Speed in unit/second of the unit.")]
        [field: ReadOnly]
        public float MoveSpeed { get; set; } = 0.1f;
        public void SetMoveDirection(MoveDirection newMoveDirection)
        {
            moveDirection = newMoveDirection;
        }


        private void Awake()
        {
            unitBehaviour = GetComponent<UnitBehaviour>();
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
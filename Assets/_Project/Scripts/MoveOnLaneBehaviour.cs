using UnityEngine;

namespace Kamikaze
{
    /// <summary>
    /// Makes a unit move on the lane with a specified speed and direction.
    /// </summary>
    [RequireComponent(typeof(UnitBehaviour))]
    public class MoveOnLaneBehaviour : MonoBehaviour
    {
        [Tooltip("Speed in unit/second of the unit.")] [SerializeField]
        private float moveSpeed = 0.1f;

        [SerializeField] private MoveDirection moveDirection = MoveDirection.Right;

        private UnitBehaviour unitBehaviour;

        private void Awake()
        {
            unitBehaviour = GetComponent<UnitBehaviour>();
        }

        private void Update()
        {
            float moveModifier = moveDirection == MoveDirection.Left ? 1 : -1;
            float move = moveSpeed * moveModifier;
            unitBehaviour.Position -= move * Time.deltaTime;
        }
    }
}
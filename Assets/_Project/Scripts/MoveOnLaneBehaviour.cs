using UnityEngine;

namespace Kamikaze
{
    public enum MoveDirection
    {
        Right,
        Left,
    }

    public class MoveOnLaneBehaviour : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 0.1f;
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
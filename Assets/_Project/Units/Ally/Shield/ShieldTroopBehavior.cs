using System;
using UnityEngine;

namespace Kamikaze.Units.Ally.Shield
{
    [RequireComponent(typeof(LaneUnitBehaviour))]
    [RequireComponent(typeof(MoveOnLaneBehaviour))]
    [RequireComponent(typeof(HealthBehaviour))]
    public class ShieldTroopBehavior : MonoBehaviour
    {
        [SerializeField] private GameObject shieldGo;
        [SerializeField] private float stopPosition;
        [SerializeField] private int shieldHealthPoints = 5;

        private LaneUnitBehaviour unitBehaviour;
        private MoveOnLaneBehaviour moveOnLaneBehaviour;
        private HealthBehaviour healthBehaviour;
        private ShieldState state = ShieldState.Walking;

        private bool PassedPosition
        {
            get
            {
                return moveOnLaneBehaviour.Direction switch
                {
                    MoveDirection.Right => unitBehaviour.Position >= stopPosition,
                    MoveDirection.Left => unitBehaviour.Position <= stopPosition,
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }
        }

        private void Awake()
        {
            unitBehaviour = GetComponent<LaneUnitBehaviour>();
            moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
            healthBehaviour = GetComponent<HealthBehaviour>();
        }

        private void Update()
        {
            if (!(state == ShieldState.Walking && PassedPosition)) return;

            state = ShieldState.Shielding;
            healthBehaviour.HealthPoints = shieldHealthPoints;
            moveOnLaneBehaviour.MoveSpeed = 0f;
            shieldGo.transform.localScale = new Vector3(0.20000000f, 0.9f, 0.9f);
        }
    }
}
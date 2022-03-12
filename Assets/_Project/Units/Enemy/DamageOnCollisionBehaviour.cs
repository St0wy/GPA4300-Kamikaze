using System;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Enemy
{
    [RequireComponent(typeof(MoveOnLaneBehaviour))]
    public class DamageOnCollisionBehaviour : MonoBehaviour
    {
        [Tooltip("The tag that this object will damage.")] [Tag] [SerializeField]
        private string tagToDamage = string.Empty;

        [Tooltip("The amount of damage that the unit will inflict everytime they attack.")] [SerializeField]
        private int damage = 1;

        [Tooltip("The number of attacks per second.")] [SerializeField]
        private float attackSpeed = 0.5f;

        private EnemyState state = EnemyState.Walking;
        private HealthBehaviour target;
        private MoveOnLaneBehaviour moveOnLaneBehaviour;
        private float attackTimer;
        private float oldSpeed;

        public EnemyState State
        {
            get => state;
            set
            {
                state = value;
                switch (State)
                {
                    case EnemyState.Walking:
                        moveOnLaneBehaviour.MoveSpeed = oldSpeed;
                        break;
                    case EnemyState.Attacking:
                        oldSpeed = moveOnLaneBehaviour.MoveSpeed;
                        moveOnLaneBehaviour.MoveSpeed = 0f;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void Awake()
        {
            moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
            oldSpeed = moveOnLaneBehaviour.MoveSpeed;
        }

        private void Update()
        {
            if (State != EnemyState.Attacking) return;

            attackTimer -= Time.deltaTime;

            if (!(attackTimer <= 0)) return;

            target.ReduceHealth(damage);
            attackTimer = attackSpeed;

            if (!target.IsAlive)
            {
                State = EnemyState.Walking;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag(tagToDamage)) return;

            var healthBehaviour = collision.gameObject.GetComponent<HealthBehaviour>();
            if (healthBehaviour == null) return;

            State = EnemyState.Attacking;
            target = healthBehaviour;
        }
    }
}
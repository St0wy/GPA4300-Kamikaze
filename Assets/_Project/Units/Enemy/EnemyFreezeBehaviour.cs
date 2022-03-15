using System;
using System.Collections;
using Kamikaze.Units.Ally.Freezer;
using UnityEngine;

namespace Kamikaze.Units.Enemy
{
    [RequireComponent(typeof(FreezeBehaviour))]
    public class EnemyFreezeBehaviour : MonoBehaviour
    {
        [SerializeField] private float frozenSpeed = 0.02f;

        private MoveOnLaneBehaviour moveOnLaneBehaviour;
        private FreezeBehaviour freezeBehaviour;
        private float baseSpeed;

        private void Awake()
        {
            moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
            freezeBehaviour = GetComponent<FreezeBehaviour>();

            if (freezeBehaviour == null) return;
            freezeBehaviour.OnFreeze += OnFreeze;
            freezeBehaviour.OnUnFreeze += OnUnFreeze;
        }

        private void OnFreeze()
        {
            baseSpeed = moveOnLaneBehaviour.MoveSpeed;
            moveOnLaneBehaviour.MoveSpeed = frozenSpeed;
        }

        private void OnUnFreeze()
        {
            moveOnLaneBehaviour.MoveSpeed = baseSpeed;
        }
    }
}
﻿using UnityEngine;

namespace Kamikaze.Units.Ally
{
    [RequireComponent(typeof(HealthBehaviour), typeof(MoveOnLaneBehaviour))]
    public class AllyTroopBehaviour : MonoBehaviour
    {
        [SerializeField] private AllyTroopScriptableObject allyTroopScriptableObject;

        private HealthBehaviour healthBehaviour;
        private MoveOnLaneBehaviour moveOnLaneBehaviour;

        private void Awake()
        {
            healthBehaviour = GetComponent<HealthBehaviour>();
            moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
            healthBehaviour.MaxHealthPoints = allyTroopScriptableObject.HealthPoints;
            moveOnLaneBehaviour.MoveSpeed = allyTroopScriptableObject.MoveSpeed;
        }
    }
}
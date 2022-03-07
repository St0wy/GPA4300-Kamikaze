using UnityEngine;

namespace Kamikaze.ScriptableObjects
{
    [CreateAssetMenu(fileName = "allyTroop", menuName = "Troop/Ally", order = 0)]
    public class AllyTroopScriptableObject : ScriptableObject
    {
        [SerializeField] private int healthPoints;
        [SerializeField] private float moveSpeed;

        [Tooltip("Price of the troop in $.")] [SerializeField]
        private int cost;

        public int HealthPoints => healthPoints;

        public float MoveSpeed => moveSpeed;

        public int Cost => cost;
    }
}
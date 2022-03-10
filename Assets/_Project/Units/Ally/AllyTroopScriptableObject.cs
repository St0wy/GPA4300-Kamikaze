using UnityEngine;

namespace Kamikaze.Units.Ally
{
    [CreateAssetMenu(fileName = "allyTroop", menuName = "Troops/Ally", order = 0)]
    public class AllyTroopScriptableObject : TroopScriptableObject
    {
        [Tooltip("Price of the troop in $.")] [SerializeField]
        private int cost;

        public int Cost => cost;
    }
}
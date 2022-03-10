using UnityEngine;

namespace Kamikaze.Units
{
    public abstract class TroopScriptableObject : ScriptableObject
    {
        [SerializeField] private int healthPoints;
        [SerializeField] private float moveSpeed;
        
        public int HealthPoints => healthPoints;
        public float MoveSpeed => moveSpeed;
    }
}
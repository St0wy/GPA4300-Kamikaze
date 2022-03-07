using System;
using MyBox;
using UnityEngine;

namespace Kamikaze
{
    public class DamageOnCollisionBehaviour : MonoBehaviour
    {
        [Tag] [SerializeField] private string tagToDamage = string.Empty;
        [SerializeField] private int damage = 1;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag(tagToDamage)) return;
            
            var healthBehaviour = collision.gameObject.GetComponent<HealthBehaviour>();
            if (healthBehaviour != null)
            {
                healthBehaviour.ReduceHealth(damage);
            }
        }
    }
}
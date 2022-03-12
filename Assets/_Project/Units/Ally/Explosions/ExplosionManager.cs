using System;
using System.Collections.Generic;
using Kamikaze.Audio;
using Kamikaze.Units.Enemy;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Ally.Explosions
{
    public class ExplosionManager : MonoBehaviour
    {
        [SerializeField] private SoundEffectScriptableObject explosionSound;
        [SerializeField] private GameObject bigExplosionPrefab;
        [SerializeField] private GameObject smallExplosionPrefab;

        [Tooltip("The max number of colliders that an explosion can have.")] [SerializeField]
        private int maxColliders = 50;

        private Stack<ExplosionBehaviour> bigExplosions;
        private Stack<ExplosionBehaviour> smallExplosions;
        private Collider[] explosionColliders;

        private void Awake()
        {
            bigExplosions = new Stack<ExplosionBehaviour>();
            smallExplosions = new Stack<ExplosionBehaviour>();
            explosionColliders = new Collider[maxColliders];
        }

        public void TriggerExplosion(Vector3 position, ExplosionScriptableObject explosionScriptable)
        {
            DealDamage(position, explosionScriptable);
            ShowExplosionAnimation(position, explosionScriptable);
            explosionSound.Play();
        }

        private ExplosionBehaviour GetBigExplosionInstance()
        {
            if (bigExplosions.Count != 0) return bigExplosions.Pop();

            var eb = Instantiate(bigExplosionPrefab).GetComponent<ExplosionBehaviour>();
            eb.ExplosionManager = this;
            return eb;
        }

        private ExplosionBehaviour GetSmallExplosionInstance()
        {
            if (smallExplosions.Count != 0) return smallExplosions.Pop();

            var eb = Instantiate(smallExplosionPrefab).GetOrAddComponent<ExplosionBehaviour>();
            eb.ExplosionManager = this;
            return eb;
        }

        private void ShowExplosionAnimation(Vector3 position, ExplosionScriptableObject explosionScriptable)
        {
            ExplosionBehaviour explosion = explosionScriptable.Type switch
            {
                ExplosionType.Big => GetBigExplosionInstance(),
                ExplosionType.Small => GetSmallExplosionInstance(),
                _ => throw new ArgumentOutOfRangeException(),
            };

            explosion.Initialize(position, explosionScriptable);
        }

        private void DealDamage(Vector3 position, ExplosionScriptableObject explosionScriptable)
        {
            int size = Physics.OverlapSphereNonAlloc(position, explosionScriptable.ExplosionRadius,
                explosionColliders);

            for (var i = 0; i < size; i++)
            {
                var hurtOnExplosionBehaviour = explosionColliders[i].GetComponent<HurtOnExplosionBehaviour>();
                if (hurtOnExplosionBehaviour == null) continue;

                float distance = Vector3.Distance(hurtOnExplosionBehaviour.transform.position, position);
                float damage = ComputeDamage(distance, explosionScriptable);
                hurtOnExplosionBehaviour.Hurt((int) damage);
            }
        }

        private static float ComputeDamage(float distance, ExplosionScriptableObject explosionScriptable)
        {
            if (distance < explosionScriptable.MaxDamageMargin)
            {
                return explosionScriptable.MaxExplosionDamage;
            }

            float distDiff = distance - explosionScriptable.MaxDamageMargin;
            // Damage equation so that the damages are lowered the furthest the explosion happens
            float damage =
                (explosionScriptable.MaxExplosionDamage * explosionScriptable.RadiusDifference *
                    explosionScriptable.RadiusDifference - explosionScriptable.MaxExplosionDamage * distDiff) /
                (explosionScriptable.RadiusDifference * explosionScriptable.RadiusDifference);
            return Mathf.Clamp(damage, 0, explosionScriptable.MaxExplosionDamage);
        }

        public void TakeBack(ExplosionBehaviour explosionBehaviour)
        {
            explosionBehaviour.gameObject.SetActive(false);
            switch (explosionBehaviour.ScriptableObject.Type)
            {
                case ExplosionType.Big:
                    bigExplosions.Push(explosionBehaviour);
                    break;
                case ExplosionType.Small:
                    smallExplosions.Push(explosionBehaviour);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
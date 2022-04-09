using System;
using System.Collections.Generic;
using Kamikaze.Units.Enemy;
using MyBox;
using UnityEngine;

namespace Kamikaze.Units.Ally.Explosions
{
	public delegate void ExplosionEvent(Collider col);

	public class ExplosionManager : MonoBehaviour
	{
		[SerializeField] private GameObject bigExplosionPrefab;
		[SerializeField] private GameObject smallExplosionPrefab;
		[SerializeField] private GameObject freezeExplosionPrefab;

		[Tooltip("The max number of colliders that an explosion can have.")] [SerializeField]
		private int maxColliders = 50;

		private Stack<ExplosionBehaviour> bigExplosions;
		private Collider[] explosionColliders;
		private Stack<ExplosionBehaviour> freezeExplosions;
		private Stack<ExplosionBehaviour> smallExplosions;

		private void Awake()
		{
			bigExplosions = new Stack<ExplosionBehaviour>();
			smallExplosions = new Stack<ExplosionBehaviour>();
			freezeExplosions = new Stack<ExplosionBehaviour>();
			explosionColliders = new Collider[maxColliders];
		}

		public void TriggerExplosion(Vector3 position, ExplosionScriptableObject explosionScriptable,
			ExplosionEvent explosionEvent = null)
		{
			DealDamage(position, explosionScriptable, explosionEvent);
			ShowExplosionAnimation(position, explosionScriptable);
		}

		private ExplosionBehaviour GetExplosionInstance(Stack<ExplosionBehaviour> stack, GameObject prefab)
		{
			if (stack.Count != 0) return stack.Pop();

			var eb = Instantiate(prefab).GetOrAddComponent<ExplosionBehaviour>();
			eb.ExplosionManager = this;
			return eb;
		}

		private void ShowExplosionAnimation(Vector3 position, ExplosionScriptableObject explosionScriptable)
		{
			ExplosionBehaviour explosion = explosionScriptable.Type switch
			{
				ExplosionType.Big => GetExplosionInstance(bigExplosions, bigExplosionPrefab),
				ExplosionType.Small => GetExplosionInstance(smallExplosions, smallExplosionPrefab),
				ExplosionType.Freeze => GetExplosionInstance(freezeExplosions, freezeExplosionPrefab),
				_ => throw new ArgumentOutOfRangeException(),
			};

			explosion.Initialize(position, explosionScriptable);
		}

		private void DealDamage(Vector3 position, ExplosionScriptableObject explosionScriptable,
			ExplosionEvent explosionEvent)
		{
			int size = Physics.OverlapSphereNonAlloc(position, explosionScriptable.ExplosionRadius,
				explosionColliders);

			for (var i = 0; i < size; i++)
			{
				Collider explosionCol = explosionColliders[i];

				var hurtOnExplosionBehaviour = explosionCol.GetComponent<HurtOnExplosionBehaviour>();
				if (hurtOnExplosionBehaviour == null) continue;

				float distance = Vector3.Distance(hurtOnExplosionBehaviour.transform.position, position);
				float damage = ComputeDamage(distance, explosionScriptable);
				hurtOnExplosionBehaviour.Hurt((int) damage);

				explosionEvent?.Invoke(explosionCol);
			}
		}

		private static float ComputeDamage(float distance, ExplosionScriptableObject explosionScriptable)
		{
			if (distance < explosionScriptable.MaxDamageMargin) return explosionScriptable.MaxExplosionDamage;

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
				case ExplosionType.Freeze:
					freezeExplosions.Push(explosionBehaviour);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
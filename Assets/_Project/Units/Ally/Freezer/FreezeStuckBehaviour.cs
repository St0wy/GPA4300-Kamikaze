﻿using System.Collections;
using MyBox;
using UnityEngine;
using Kamikaze.Units.Enemy;
using Kamikaze.Units.Enemy.Shield;

namespace Kamikaze.Units.Ally.Freezer
{
	[RequireComponent(typeof(MoveOnLaneBehaviour))]
	public class FreezeStuckBehaviour : MonoBehaviour
	{
		[SerializeField] private float stuckTime = 1.5f;
		private float baseSpeed;

		private MoveOnLaneBehaviour moveOnLaneBehaviour;
		[SerializeField] private FreezeStuckIndicatorBehaviour freezeStuckIndicator;

		[field: ReadOnly]
		[field: SerializeField]
		public bool IsStuck { get; private set; }

		private void Awake()
		{
			moveOnLaneBehaviour = GetComponent<MoveOnLaneBehaviour>();
			baseSpeed = moveOnLaneBehaviour.MoveSpeed;
		}

		private void Update()
		{
			if (IsStuck)
            {
				moveOnLaneBehaviour.MoveSpeed = 0f;
				freezeStuckIndicator.gameObject.SetActive(true);
				freezeStuckIndicator.StartAnim(1.4f, 20);
			}

            else
            {
				freezeStuckIndicator.gameObject.SetActive(false);
			}
				
		}

		public void Stuck()
		{
			moveOnLaneBehaviour.MoveSpeed = 0f;
			IsStuck = true;
			ExplosionProtection explosionProtection = GetComponent<ExplosionProtection>();
			if(explosionProtection!=null)
            {
				
				if(explosionProtection.IsEnabled)
                {
					explosionProtection.IsEnabled = false;
					Debug.Log("shield enemy is now vulnerable");
				}
            }
			StartCoroutine(UnStuckCoroutine());
		}

		private IEnumerator UnStuckCoroutine()
		{		
			yield return new WaitForSeconds(stuckTime);
			moveOnLaneBehaviour.MoveSpeed = baseSpeed;			
			IsStuck = false;
			ExplosionProtection explosionProtection = GetComponent<ExplosionProtection>();
			if (explosionProtection != null)
			{
				if (!explosionProtection.IsEnabled)
				{

					explosionProtection.IsEnabled = true;
					Debug.Log("shield enemy is now invulnerable");
				}
			}
		}
	}
}
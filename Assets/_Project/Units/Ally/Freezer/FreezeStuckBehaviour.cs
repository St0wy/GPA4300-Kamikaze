﻿using System.Collections;
using MyBox;
using UnityEngine;
using Kamikaze.Units.Enemy;

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
			StartCoroutine(UnStuckCoroutine());
		}

		private IEnumerator UnStuckCoroutine()
		{
			yield return new WaitForSeconds(stuckTime);
			moveOnLaneBehaviour.MoveSpeed = baseSpeed;
			IsStuck = false;
		}
	}
}
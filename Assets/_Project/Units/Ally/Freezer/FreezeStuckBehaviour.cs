using System.Collections;
using MyBox;
using UnityEngine;
using Kamikaze.Units.Enemy;
using Kamikaze.Units.Enemy.Shield;
using Kamikaze.Audio;

namespace Kamikaze.Units.Ally.Freezer
{
	[RequireComponent(typeof(MoveOnLaneBehaviour))]
	public class FreezeStuckBehaviour : MonoBehaviour
	{
		[SerializeField] private float stuckTime = 1.5f;
		private float baseSpeed;

		private MoveOnLaneBehaviour moveOnLaneBehaviour;
		[SerializeField] private FreezeStuckIndicatorBehaviour freezeStuckIndicator;
		[SerializeField] private SoundEffectScriptableObject freezeStuckSound;

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
			freezeStuckSound.Play();
			moveOnLaneBehaviour.MoveSpeed = 0f;
			IsStuck = true;
			ExplosionProtection explosionProtection = GetComponent<ExplosionProtection>();
			if(explosionProtection!=null)
            {			
				if(explosionProtection.IsProtected)
                {
					explosionProtection.IsProtected = false;
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
				if (!explosionProtection.IsProtected)
				{
					explosionProtection.IsProtected = true;
					Debug.Log("shield enemy is now invulnerable");
				}
			}
		}
	}
}
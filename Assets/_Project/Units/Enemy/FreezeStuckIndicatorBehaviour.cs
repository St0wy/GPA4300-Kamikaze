using UnityEngine;

namespace Kamikaze.Units.Enemy
{
	public class FreezeStuckIndicatorBehaviour : MonoBehaviour
	{
		[SerializeField] private float startScale;
		[SerializeField] private Transform component;
		private float animTargetScale;
		private float animSpeed;
		private bool canStartAnim;

		private void Start()
		{
			component.localScale = new Vector3(startScale, startScale, startScale);
		}

		private void Update()
		{
			if (!canStartAnim) return;
			
			if (component.localScale.x < animTargetScale
			    && component.localScale.y < animTargetScale
			    && component.localScale.z < animTargetScale)
			{
				component.localScale += new Vector3(Time.deltaTime * animSpeed, Time.deltaTime * animSpeed,
					Time.deltaTime * animSpeed);
			}
			else
			{
				canStartAnim = false;
			}
		}

		public void StartAnim(float targetScale, float speed)
		{
			animTargetScale = targetScale;
			animSpeed = speed;
			canStartAnim = true;
		}
	}
}
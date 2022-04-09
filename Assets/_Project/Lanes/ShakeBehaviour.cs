using UnityEngine;

namespace Kamikaze.Lanes
{
	public class ShakeBehaviour : MonoBehaviour
	{
		[SerializeField] private float shakePower;
		[SerializeField] private float shakeDuration;
		private Vector3 initialPos;
		private float timeUntilEndOfShake;


		private void Start()
		{
			initialPos = transform.position;
		}

		private void LateUpdate()
		{
			if (timeUntilEndOfShake > 0)
			{
				timeUntilEndOfShake -= Time.deltaTime;

				float xShake = -1f * shakePower;
				transform.position += new Vector3(xShake, 0, 0);
			}
			else
			{
				transform.position = initialPos;
			}
		}

		public void StartShake()
		{
			timeUntilEndOfShake = shakeDuration;
		}
	}
}
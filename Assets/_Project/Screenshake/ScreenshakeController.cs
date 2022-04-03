using UnityEngine;

namespace Kamikaze.Screenshake
{
	public class ScreenshakeController : MonoBehaviour
	{
		private float timeUntilEndOfShake, shakePower;
		private Vector3 initialPosition;

		public static ScreenshakeController Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			initialPosition = transform.position;
		}

		private void LateUpdate()
		{
			if (timeUntilEndOfShake > 0)
			{
				timeUntilEndOfShake -= Time.deltaTime;

				float xShake = Random.Range(-1f, 1f) * shakePower;
				float yShake = Random.Range(-1f, 1f) * shakePower;

				transform.position += new Vector3(xShake, yShake, 0);
			}
			else
			{
				transform.position = initialPosition;
			}
		}

		public void StartScreenShake(float power, float duration)
		{
			timeUntilEndOfShake = duration;
			shakePower = power;
		}
	}
}
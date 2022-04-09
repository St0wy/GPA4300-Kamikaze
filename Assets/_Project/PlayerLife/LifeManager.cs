using Kamikaze.Screenshake;
using UnityEngine;

namespace Kamikaze.PlayerLife
{
	public class LifeManager : MonoBehaviour
	{
		public delegate void HurtEvent();

		[SerializeField] private int playerLife = 5;

		public int PlayerLife => playerLife;

		public bool IsAlive => playerLife > 0;

		public HurtEvent OnHurt { get; set; }

		public void Hurt()
		{
			if (playerLife > 0)
			{
				playerLife--;
				ScreenshakeController.Instance.StartScreenShake(0.2f, 0.2f);
			}

			OnHurt?.Invoke();
		}
	}
}
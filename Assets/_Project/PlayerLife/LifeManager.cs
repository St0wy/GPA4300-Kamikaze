using UnityEngine;
using UnityEngine.UI;

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
			}

			OnHurt?.Invoke();
		}
	}
}
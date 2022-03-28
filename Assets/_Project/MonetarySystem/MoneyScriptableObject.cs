using UnityEngine;

namespace Kamikaze.MonetarySystem
{
	[CreateAssetMenu(fileName = "money", menuName = "Data/Money", order = 0)]
	public class MoneyScriptableObject : ScriptableObject
	{
		[SerializeField] private int money;
		[SerializeField] private int gemsValue = 5;

		public int Money
		{
			get => money;
			set => money = value;
		}

		public int GemsValue => gemsValue;

		public void AddGem(DropBehaviour gem)
		{
			money += gem.DropAmount * GemsValue;
		}
	}
}
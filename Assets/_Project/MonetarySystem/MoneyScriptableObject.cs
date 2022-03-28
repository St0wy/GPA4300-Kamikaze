using UnityEngine;

namespace Kamikaze.MonetarySystem
{
	[CreateAssetMenu(fileName = "money", menuName = "Data/Money", order = 0)]
	public class MoneyScriptableObject : ScriptableObject
	{
		public int Money { get; set; }
	}
}
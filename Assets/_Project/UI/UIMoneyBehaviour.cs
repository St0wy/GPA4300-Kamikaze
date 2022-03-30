using Kamikaze.MonetarySystem;
using TMPro;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UIMoneyBehaviour : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI text;
		[SerializeField] private MoneyScriptableObject money;

		private void Update()
		{
			text.text = $"{money.Money} $";
		}
	}
}
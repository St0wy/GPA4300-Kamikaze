using TMPro;
using UnityEngine;

namespace Kamikaze.MonetarySystem
{
	public class UIDropBehaviour : MonoBehaviour
	{
		[SerializeField] private DropManager dropManager;
		private TextMeshProUGUI textMeshProUGUI;

		private void Awake()
		{
			textMeshProUGUI = GetComponent<TextMeshProUGUI>();
		}

		private void Update()
		{
			textMeshProUGUI.text = dropManager.DropQuantity.ToString();
		}
	}
}
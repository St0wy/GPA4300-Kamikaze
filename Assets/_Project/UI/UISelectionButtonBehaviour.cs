using MyBox;
using UnityEngine;

namespace Kamikaze.UI
{
	public class UISelectionButtonBehaviour : MonoBehaviour
	{
		[ReadOnly] [SerializeField] private bool isSelected;
		[SerializeField] private GameObject selectionBrackets;
		[SerializeField] private int unitId;

		public bool IsSelected
		{
			get => isSelected;
			set
			{
				isSelected = value;
				selectionBrackets.SetActive(isSelected);
			}
		}

		public int UnitId => unitId;

		[ButtonMethod]
		public void ToggleIsSelected()
		{
			IsSelected = !IsSelected;
		}
	}
}
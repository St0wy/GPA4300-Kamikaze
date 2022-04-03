using JetBrains.Annotations;
using MyBox;
using UnityEngine;
using Kamikaze.UnlockSystem;

namespace Kamikaze.UI
{
	public class UISelectionButtonBehaviour : MonoBehaviour
	{
		[ReadOnly] [SerializeField] private bool isSelected;
		[SerializeField] private GameObject selectionBrackets;
		[SerializeField] private int unitId;
		[SerializeField] private UIShowTroopButtonBehaviour showTroopButtonBehaviour;

		public UIShowTroopButtonBehaviour ShowTroopButtonBehaviour => showTroopButtonBehaviour;

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
		[UsedImplicitly]
		public void ToggleIsSelected()
		{
			IsSelected = !IsSelected;
		}
	}
}
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Kamikaze.Units
{
	public class KeyboardUnitSelector : MonoBehaviour
	{
		[SerializeField] private Button[] unitsButtons;

		private void Update()
		{
			if (Keyboard.current.digit1Key.isPressed)
			{
				if (unitsButtons[0].IsInteractable() && unitsButtons[0].isActiveAndEnabled)
					unitsButtons[0].onClick?.Invoke();
			}

			if (Keyboard.current.digit2Key.isPressed)
			{
				if (unitsButtons[1].IsInteractable() && unitsButtons[1].isActiveAndEnabled)
					unitsButtons[1].onClick?.Invoke();
			}

			if (Keyboard.current.digit3Key.isPressed)
			{
				if (unitsButtons[2].IsInteractable() && unitsButtons[2].isActiveAndEnabled)
					unitsButtons[2].onClick?.Invoke();
			}

			// ReSharper disable once InvertIf
			if (Keyboard.current.digit4Key.isPressed)
			{
				if (unitsButtons[3].IsInteractable() && unitsButtons[3].isActiveAndEnabled)
					unitsButtons[3].onClick?.Invoke();
			}
		}
	}
}
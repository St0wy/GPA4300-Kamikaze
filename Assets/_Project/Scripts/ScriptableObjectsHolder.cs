using Kamikaze.LevelSelect;
using Kamikaze.MonetarySystem;
using UnityEngine;

namespace Kamikaze
{
	public class ScriptableObjectsHolder : MonoBehaviour
	{
		[SerializeField] private LevelsManagerScriptableObject levelsManager;
		[SerializeField] private InventoryScriptableObject inventory;
		[SerializeField] private MoneyScriptableObject money;
	}
}
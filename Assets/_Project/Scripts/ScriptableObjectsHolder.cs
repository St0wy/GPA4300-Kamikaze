using JetBrains.Annotations;
using Kamikaze.LevelSelect;
using Kamikaze.MonetarySystem;
using UnityEngine;

namespace Kamikaze
{
	public class ScriptableObjectsHolder : MonoBehaviour
	{
		[UsedImplicitly] [SerializeField] private LevelsManagerScriptableObject levelsManager;
		[UsedImplicitly] [SerializeField] private InventoryScriptableObject inventory;
		[UsedImplicitly] [SerializeField] private MoneyScriptableObject money;
	}
}
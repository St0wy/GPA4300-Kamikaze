using UnityEngine;

namespace Kamikaze.Lanes
{
	public class UnitSelector : MonoBehaviour
	{
		[SerializeField] private GameObject[] unitsPrefabs;

		[field: SerializeField] public int SelectedUnitId { get; set; }

		public GameObject SelectedUnit => unitsPrefabs[SelectedUnitId];

		public int PrefabsLength => unitsPrefabs.Length;
	}
}
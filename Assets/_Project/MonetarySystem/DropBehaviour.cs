using UnityEngine;

namespace Kamikaze.MonetarySystem
{
	public class DropBehaviour : MonoBehaviour
	{
		[field: SerializeField] public int DropAmount { get; set; } = 1;
	}
}
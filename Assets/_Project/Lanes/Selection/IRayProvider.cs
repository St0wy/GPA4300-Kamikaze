using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
	public interface IRayProvider
	{
		Ray CreateRay();
	}
}
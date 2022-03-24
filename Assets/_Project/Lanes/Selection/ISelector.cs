using UnityEngine;

namespace Kamikaze.Lanes.Selection
{
	public interface ISelector
	{
		Transform Selection { get; }
		Vector3 Point { get; }
		void Check(Ray ray);
	}
}
using UnityEngine;

namespace Kamikaze
{
	public static class VectorUtils
	{
		public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
		{
			Vector3 ab = b - a;
			Vector3 av = value - a;
			return Vector3.Dot(av, ab) / Vector3.Dot(ab, ab);
		}
	}
}
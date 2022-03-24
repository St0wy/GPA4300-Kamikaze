using UnityEngine;

namespace Kamikaze
{
	public static class VectorUtils
	{
		/// <summary>
		///     Computes the InverseLerp for a vector 3. Equivalent of <see cref="Mathf.InverseLerp" />.
		/// </summary>
		/// <param name="a">Start position.</param>
		/// <param name="b">End position.</param>
		/// <param name="value">
		///     Position in the world that should be transformed
		///     to a value between <see cref="a" /> and <see cref="b" />.
		/// </param>
		/// <returns>
		///     A float that represents the position of value between <see cref="a" /> and <see cref="b" />.
		///     Where 0 = <see cref="a" /> and 1 = <see cref="b" />.
		/// </returns>
		public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
		{
			Vector3 ab = b - a;
			Vector3 av = value - a;
			return Vector3.Dot(av, ab) / Vector3.Dot(ab, ab);
		}
	}
}
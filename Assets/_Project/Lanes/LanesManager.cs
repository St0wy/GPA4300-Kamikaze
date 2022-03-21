using System;
using UnityEngine;

namespace Kamikaze.Lanes
{
	/// <summary>
	/// Manages the lanes in the scene.
	/// </summary>
	public class LanesManager : MonoBehaviour
	{
		[SerializeField] private Lane[] lanes;

		/// <summary>
		/// Gets the lanes array.
		/// </summary>
		public Lane[] Lanes => lanes;

		private void Awake()
		{
			for (var i = 0; i < Lanes.Length; i++)
			{
				Lanes[i].Id = i;
			}
		}
	}
}
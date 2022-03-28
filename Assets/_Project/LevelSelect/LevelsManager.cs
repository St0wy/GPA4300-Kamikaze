using System;
using UnityEngine;

namespace Kamikaze.LevelSelect
{
	public class LevelsManager : MonoBehaviour
	{
		[SerializeField] private Level[] levels;
		[SerializeField] public Color lockedColor;
		[SerializeField] private Color finishedColor;
		[SerializeField] private Color playableColor;

		public Level[] Levels => levels;
		public Color LockedColor => lockedColor;
		public Color FinishedColor => finishedColor;
		public Color PlayableColor => playableColor;

		private void Awake()
		{
			DontDestroyOnLoad(this);
		}
	}
}
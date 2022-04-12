using System.Linq;
using UnityEngine;

namespace Kamikaze.LevelSelect
{
	[CreateAssetMenu(order = 0, fileName = "levelsManager", menuName = "Levels/Levels Manager")]
	public class LevelsManagerScriptableObject : ScriptableObject
	{
		[SerializeField] public Color lockedColor;
		[SerializeField] private Color finishedColor;
		[SerializeField] private Color playableColor;
		[SerializeField] private int currentLevelId;
		[SerializeField] private Level[] levels;

		public int CurrentLevelId
		{
			get => currentLevelId;
			set => currentLevelId = value;
		}

		public Level[] Levels => levels;
		public Color LockedColor => lockedColor;
		public Color FinishedColor => finishedColor;
		public Color PlayableColor => playableColor;

		public bool AreAllLevelsFinished => Levels.All(level => level.LevelStatus == LevelStatus.Finished);

		public void FinishCurrentLevel()
		{
			CurrentLevelId++;

			for (var i = 0; i < levels.Length; i++)
			{
				if (i < CurrentLevelId)
					levels[i].LevelStatus = LevelStatus.Finished;
				else if (i == CurrentLevelId)
					levels[i].LevelStatus = LevelStatus.Playable;
				else if (i > CurrentLevelId) levels[i].LevelStatus = LevelStatus.Locked;
			}
		}
	}
}
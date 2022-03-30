using UnityEngine;

namespace Kamikaze.LevelSelect
{
	[CreateAssetMenu(order = 0, fileName = "levelsManager", menuName = "Levels/Levels Manager")]
	public class LevelsManagerScriptableObject : ScriptableObject
	{
		[SerializeField] private Level[] levels;
		[SerializeField] public Color lockedColor;
		[SerializeField] private Color finishedColor;
		[SerializeField] private Color playableColor;

		private int currentLevelId;

		public Level[] Levels => levels;
		public Color LockedColor => lockedColor;
		public Color FinishedColor => finishedColor;
		public Color PlayableColor => playableColor;

		public void FinishCurrentLevel()
		{
			currentLevelId++;
			
			for (var i = 0; i < levels.Length; i++)
			{
				if (i < currentLevelId)
				{
					levels[i].LevelStatus = LevelStatus.Finished;
				} else if (i == currentLevelId)
				{
					levels[i].LevelStatus = LevelStatus.Playable;
				} else if (i > currentLevelId)
				{
					levels[i].LevelStatus = LevelStatus.Locked;
				}
			}
		}
	}
}